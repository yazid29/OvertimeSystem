using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class OvertimeService : IOvertimeService
    {
        private readonly IOvertimeRepository _overtimeRepository;

        public OvertimeService(IOvertimeRepository overtimeRepository)
        {
            _overtimeRepository = overtimeRepository;
        }

        public async Task<IEnumerable<Overtime>?> GetAllAsync()
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


        public async Task<Overtime?> GetByIdAsync(Guid id)
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

        public async Task<int> CreateAsync(Overtime employee)
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

        public async Task<int> UpdateAsync(Guid id, Overtime employee)
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
