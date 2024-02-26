using API.DTOs.AccountRoles;
namespace API.Services.Interfaces
{
    public interface IAccountRoleService
    {
        Task<IEnumerable<AccountRoleResponseDto>?> GetAllAsync();
        Task<AccountRoleResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(AccountRoleRequestDto entity);
        Task<int> UpdateAsync(Guid id, AccountRoleRequestDto entity);
        Task<int> DeleteAsync(Guid id);
    }
}
