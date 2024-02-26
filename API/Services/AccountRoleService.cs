using API.DTOs.AccountRoles;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AccountRoleService : IAccountRoleService
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMapper _mapper;
        public AccountRoleService(IAccountRoleRepository repo)
        {
            _accountRoleRepository = repo;
        }
        public async Task<IEnumerable<AccountRoleResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _accountRoleRepository.GetAllAsync();
                var dataMap = _mapper.Map<IEnumerable<AccountRoleResponseDto>>(data);
                return dataMap; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<AccountRoleResponseDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                var dataMap = _mapper.Map<AccountRoleResponseDto>(data);
                return dataMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(AccountRoleRequestDto entity)
        {
            try
            {
                var dataMap = _mapper.Map<AccountRole>(entity);
                await _accountRoleRepository.CreateAsync(dataMap);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, AccountRoleRequestDto entity)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var accountRole = _mapper.Map<AccountRole>(entity);
                accountRole.Id = id;
                await _accountRoleRepository.UpdateAsync(accountRole);
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
                var data = await _accountRoleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _accountRoleRepository.DeleteAsync(data);
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
