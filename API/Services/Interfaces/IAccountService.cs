using API.Models;

namespace API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>?> GetAllAsync();
        Task<Account?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(Account employee);
        Task<int> UpdateAsync(Guid id, Account employee);
        Task<int> DeleteAsync(Guid id);
    }
}
