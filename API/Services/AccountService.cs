using API.DTOs.Accounts;
using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Utilities.Handlers;
using AutoMapper;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailHandler _emailHandler;

        public AccountService(IAccountRepository repo, IMapper mapper, IRoleRepository roleRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IEmailHandler emailHandler)
        {

            _accountRepository = repo;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _accountRoleRepository = accountRoleRepository;
            _employeeRepository = employeeRepository;
            _emailHandler = emailHandler;
        }
        public async Task<int> LoginAsync(LoginDto entity)
        {
            var employee = await _employeeRepository.GetByEmailAsync(entity.Email);
            if (employee == null)
            {
                return 0;
            }
            var accountEmp = await _accountRepository.GetByIdAsync(employee.Id);
            var passwordAccEmp = accountEmp.Password;
            
            var cek = BCryptHandler.VerifyPassword(entity.Password, passwordAccEmp);
            if (cek == false)
            {
                return 0;
            }
            return 1;
        }

        async Task<int> IAccountService.ForgotPasswordAsync(ForgotPasswordDto entity)
        {
            
            var employee = await _employeeRepository.GetByEmailAsync(entity.Email);
            if (employee is null)
            {
                return 0;
            }
            var email = entity.Email;
            var accountEmp = await _accountRepository.GetByIdAsync(employee.Id);
            await _employeeRepository.ChangeTrackingAsync();
            var otpCode = new Random().Next(111111, 999999);
            accountEmp.Expired = DateTime.Now.AddMinutes(5);
            accountEmp.IsUsed = false;
            accountEmp.Otp = otpCode;

            await _accountRepository.UpdateAsync(accountEmp);
            await _accountRepository.ChangeTrackingAsync();
            var msg = $"{otpCode}";
            var emailMap = new EmailDto(email, "[Reset Password] - MBKM 6", msg);
            await _emailHandler.SendEmailAsync(emailMap);
            return otpCode;
        }

        async Task<int> IAccountService.ChangePasswordAsync(ChangePasswordRequestDto entity)
        {
            var employee = await _employeeRepository.GetByEmailAsync(entity.Email);
            if (employee == null)
            {
                return 0;
            }
            var accountEmp = await _accountRepository.GetByIdAsync(employee.Id);
            await _employeeRepository.ChangeTrackingAsync();

            if (entity.NewPassword != entity.ConfirmPassword) return 0;
            if (accountEmp.IsUsed) return 2;
            if (accountEmp.Expired < DateTime.Now) return 3;
            if (accountEmp.Otp != entity.Otp) return 4;
            // Hash the new password
            accountEmp.Password = BCryptHandler.HashPassword(entity.NewPassword);
            accountEmp.IsUsed = true;
            await _accountRepository.UpdateAsync(accountEmp);
            await _accountRepository.ChangeTrackingAsync();
            return 1;
        }
        public async Task<int> RegisterAsync(RegisterDto entity)
        {
            await using var transaction = await _accountRepository.BeginTransactionAsync();
            try
            {
                var employee = _mapper.Map<Employee>(entity);
                await _employeeRepository.CreateAsync(employee);
                await _employeeRepository.ChangeTrackingAsync();

                if (entity.Password != entity.ConfirmPassword) return 0;

                var accountEmp = _mapper.Map<Account>(entity);
                accountEmp.Id = employee.Id;
                await _accountRepository.CreateAsync(accountEmp);
                await _accountRepository.ChangeTrackingAsync();

                var role = await _roleRepository.GetGuidbyRole("employee");
                if (role == null) return 2;
                await _roleRepository.ChangeTrackingAsync();

                var accRoleEmp = new AccountRole
                {
                    AccountId = accountEmp.Id,
                    RoleId = role.Id
                };
                await _accountRoleRepository.CreateAsync(accRoleEmp);
                await _accountRoleRepository.ChangeTrackingAsync();

                await transaction.CommitAsync();
                return 1; // success
            }
            catch
            {
                await transaction.RollbackAsync();
                throw; // failed insert into tabel
            }
            
        }
        public async Task<int> AddAccountRoleAsync(AddAccountRoleRequestDto addAccountRoleRequestDto)
        {
            var account = await _accountRepository.GetByIdAsync(addAccountRoleRequestDto.AccountId);

            if (account == null)
            {
                return 0; // Account not found
            }
            var role = await _roleRepository.GetByIdAsync(addAccountRoleRequestDto.RoleId);
            if (role == null)
            {
                return -1; // Account not found
            }
            var accountRole = _mapper.Map<AccountRole>(addAccountRoleRequestDto);
            await _accountRoleRepository.CreateAsync(accountRole);
            return 1; // success
        }

        public async Task<int> RemoveRoleAsync(RemoveAccountRoleRequestDto removeAccountRoleRequestDto)
        {
            var accountRole = await _accountRoleRepository.GetDataByAccountIdAndRoleAsync(removeAccountRoleRequestDto.AccountId, removeAccountRoleRequestDto.RoleId);

            if (accountRole == null)
            {
                return 0; // Account or Role not found
            }

            await _accountRoleRepository.DeleteAsync(accountRole);

            return 1; // success
        }

        public async Task<IEnumerable<AccountResponseDto>?> GetAllAsync()
        {
            var data = await _accountRepository.GetAllAsync();

            var dataMap = _mapper.Map<IEnumerable<AccountResponseDto>>(data);

            return dataMap; // success

        }

        public async Task<AccountResponseDto?> GetByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return null; // not found
            }

            var dataMap = _mapper.Map<AccountResponseDto>(account);

            return dataMap; // success
        }

        public async Task<int> CreateAsync(AccountRequestDto accountRequestDto)
        {

            var account = _mapper.Map<Account>(accountRequestDto);

            await _accountRepository.CreateAsync(account);

            return 1; // success
        }

        public async Task<int> UpdateAsync(Guid id, AccountRequestDto entity)
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

        public async Task<int> DeleteAsync(Guid id)
        {
            var data = await _accountRepository.GetByIdAsync(id);
            if (data is null)
            {
                return 0;
            }
            await _accountRepository.DeleteAsync(data);
            return 1;
        }

    }
}
