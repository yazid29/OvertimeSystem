using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class AccountRoleService : IAccountRoleService
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleService(IAccountRoleRepository repo)
        {
            _accountRoleRepository = repo;
        }
        public async Task<IEnumerable<AccountRole>?> GetAllAsync()
        {
            try
            {
                var data = await _accountRoleRepository.GetAllAsync();
                return data; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<AccountRole?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(AccountRole employee)
        {
            try
            {
                await _accountRoleRepository.CreateAsync(employee);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, AccountRole employee)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _accountRoleRepository.UpdateAsync(employee);
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
