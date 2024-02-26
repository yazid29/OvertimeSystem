using API.DTOs.Accounts;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRoleRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repo,IMapper mapper)
        {
            _accountRoleRepository = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AccountResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _accountRoleRepository.GetAllAsync();
                var dataMap = _mapper.Map<IEnumerable<AccountResponseDto>>(data);
                return dataMap; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<AccountResponseDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                var dataMap = _mapper.Map<AccountResponseDto>(data);
                return dataMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(AccountRequestDto entity)
        {
            try
            {
                var data = _mapper.Map<Account>(entity);
                await _accountRoleRepository.CreateAsync(data);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, AccountRequestDto entity)
        {
            try
            {
                var data = await _accountRoleRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var account = _mapper.Map<Account>(entity);
                account.Id = id;
                await _accountRoleRepository.UpdateAsync(account);
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
