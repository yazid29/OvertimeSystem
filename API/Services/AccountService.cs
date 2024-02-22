using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRoleRepository;

        public AccountService(IAccountRepository repo)
        {
            _accountRoleRepository = repo;
        }
        public async Task<IEnumerable<Account>?> GetAllAsync()
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


        public async Task<Account?> GetByIdAsync(Guid id)
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

        public async Task<int> CreateAsync(Account employee)
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

        public async Task<int> UpdateAsync(Guid id, Account employee)
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
