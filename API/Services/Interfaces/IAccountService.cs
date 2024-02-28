using API.DTOs.Accounts;

namespace API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<int> LoginAsync(LoginDto entity);
        Task<int> RegisterAsync(RegisterDto entity);
        Task<int> AddAccountRoleAsync(AddAccountRoleRequestDto addAccountRoleRequestDto);
        Task<int> RemoveRoleAsync(RemoveAccountRoleRequestDto removeAccountRoleRequestDto);
        Task<IEnumerable<AccountResponseDto>?> GetAllAsync();
        Task<AccountResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(AccountRequestDto entity);
        Task<int> UpdateAsync(Guid id, AccountRequestDto entity);
        Task<int> DeleteAsync(Guid id);
    }
}
