using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class OvertimeRequestService : IOvertimeRequestService
    {
        private readonly IOvertimeRequestRepository _overtimeRepository;

        public OvertimeRequestService(IOvertimeRequestRepository overtimeRepository)
        {
            _overtimeRepository = overtimeRepository;
        }

        public async Task<IEnumerable<OvertimeRequest>?> GetAllAsync()
        {
            try
            {
                var data = await _overtimeRepository.GetAllAsync();
                return data; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<OvertimeRequest?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(OvertimeRequest employee)
        {
            try
            {
                await _overtimeRepository.CreateAsync(employee);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, OvertimeRequest employee)
        {
            try
            {
                var data = await _overtimeRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _overtimeRepository.UpdateAsync(employee);
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
