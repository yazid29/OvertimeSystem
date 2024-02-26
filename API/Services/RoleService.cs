using API.DTOs.Roles;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _roleRepository.GetAllAsync();
                var dataMap = _mapper.Map<IEnumerable<RoleResponseDto>>(data);
                return dataMap; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<RoleResponseDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _roleRepository.GetByIdAsync(id);
                var dataMap = _mapper.Map<RoleResponseDto>(data);
                return dataMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(RoleRequestDto entity)
        {
            try
            {
                var dataMap = _mapper.Map<Role>(entity);
                await _roleRepository.CreateAsync(dataMap);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, RoleRequestDto entity)
        {
            try
            {
                var data = await _roleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var dataMap = _mapper.Map<Role>(entity);
                dataMap.Id = id;
                await _roleRepository.UpdateAsync(dataMap);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                var data = await _roleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _roleRepository.DeleteAsync(data);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }
    }
}
