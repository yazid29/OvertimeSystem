using API.DTOs.Overtimes;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class OvertimeService : IOvertimeService
    {
        private readonly IOvertimeRepository _overtimeRepository;
        private readonly IMapper _mapper;
        public OvertimeService(IOvertimeRepository overtimeRepository)
        {
            _overtimeRepository = overtimeRepository;
        }

        public async Task<IEnumerable<OvertimeResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _overtimeRepository.GetAllAsync();
                var dataMap = _mapper.Map<IEnumerable<OvertimeResponseDto>>(data);
                return dataMap; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<OvertimeResponseDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                var dataMap = _mapper.Map<OvertimeResponseDto>(data);
                return dataMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(OvertimeRequestDto entity)
        {
            try
            {
                var dataMap = _mapper.Map<Overtime>(entity);
                await _overtimeRepository.CreateAsync(dataMap);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, OvertimeRequestDto entity)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var dataMap = _mapper.Map<Overtime>(entity);
                dataMap.Id = id;
                await _overtimeRepository.UpdateAsync(dataMap);
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
                var data = await _overtimeRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _overtimeRepository.DeleteAsync(data);
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
