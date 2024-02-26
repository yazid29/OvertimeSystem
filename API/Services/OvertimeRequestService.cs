using API.DTOs.OvertimeRequests;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class OvertimeRequestService : IOvertimeRequestService
    {
        private readonly IOvertimeRequestRepository _overtimeRepository;
        private readonly IMapper _mapper;
        public OvertimeRequestService(IOvertimeRequestRepository overtimeRepository)
        {
            _overtimeRepository = overtimeRepository;
        }

        public async Task<IEnumerable<OvertimeReqResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _overtimeRepository.GetAllAsync();
                var dataMap = _mapper.Map<IEnumerable<OvertimeReqResponseDto>>(data);
                return dataMap; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<OvertimeReqResponseDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                var dataMap = _mapper.Map<OvertimeReqResponseDto>(data);
                return dataMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(OvertimeReqRequestDto entity)
        {
            try
            {
                var dataMap = _mapper.Map<OvertimeRequest>(entity);
                await _overtimeRepository.CreateAsync(dataMap);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, OvertimeReqRequestDto entity)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var dataMap = _mapper.Map<OvertimeRequest>(entity);
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
