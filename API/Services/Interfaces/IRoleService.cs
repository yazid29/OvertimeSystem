using API.Models;

namespace API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>?> GetAllAsync();
        Task<Role?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(Role employee);
        Task<int> UpdateAsync(Guid id, Role employee);
        Task<int> DeleteAsync(Guid id);
    }
}
