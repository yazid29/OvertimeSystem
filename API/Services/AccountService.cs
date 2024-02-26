using API.DTOs.Accounts;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repo, IMapper mapper, IRoleRepository roleRepository, IAccountRoleRepository accountRoleRepository)
        {
            _accountRepository = repo;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
        }
        public async Task<IEnumerable<AccountResponseDto>?> GetAllAsync()
        {
            try
            {
                var data = await _accountRepository.GetAllAsync();
                var AccRole = await _accountRoleRepository.GetAllAsync();
                var role = await _roleRepository.GetAllAsync();
                var accountWithRole = from acr in AccRole
                                      join acc in data on acr.AccountId equals acc.Id
                                      join rol in role on acr.RoleId equals rol.Id
                                      select new AccountResponseDto
                                      (acc.Id, acc.Password,
                                          acc.Otp,
                                          acc.Expired,
                                          acc.IsUsed,
                                          acc.IsActive,
                                          rol.Name);
                //var dataMap = _mapper.Map<IEnumerable<AccountResponseDto>>(accountWithRole);
                return accountWithRole; //success
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
                var data = await _accountRepository.GetByIdAsync(id);
                if(data.Id.GetType() == typeof(Guid))
                {
                    var AccRole = await _accountRoleRepository.GetAllAsync();
                    var role = await _roleRepository.GetAllAsync();
                    var accountWithRole = from acr in AccRole
                                          join rol in role on acr.RoleId equals rol.Id
                                          where acr.AccountId == data.Id 
                                          select new AccountResponseDto(
                                              data.Id,
                                              data.Password,
                                              data.Otp,
                                              data.Expired,
                                              data.IsUsed,
                                              data.IsActive,
                                              rol.Name);
                    var result = accountWithRole.FirstOrDefault();
                    return result;
                }
                else
                {
                    return null;
                }
                //var dataMap = _mapper.Map<AccountResponseDto>(data);
                
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
                await _accountRepository.CreateAsync(data);

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
                var data = await _accountRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                var account = _mapper.Map<Account>(entity);
                account.Id = id;
                await _accountRepository.UpdateAsync(account);
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
                var data = await _accountRepository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _accountRepository.DeleteAsync(data);
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
