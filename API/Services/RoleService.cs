using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>?> GetAllAsync()
        {
            try
            {
                var data = await _roleRepository.GetAllAsync();
                return data; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<Role?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _roleRepository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(Role employee)
        {
            try
            {
                await _roleRepository.CreateAsync(employee);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, Role employee)
        {
            try
            {
                var data = await _roleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _roleRepository.UpdateAsync(employee);
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
