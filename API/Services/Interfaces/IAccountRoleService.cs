using API.Models;

namespace API.Services.Interfaces
{
    public interface IAccountRoleService
    {
        Task<IEnumerable<AccountRole>?> GetAllAsync();
        Task<AccountRole?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(AccountRole employee);
        Task<int> UpdateAsync(Guid id, AccountRole employee);
        Task<int> DeleteAsync(Guid id);
    }
}
