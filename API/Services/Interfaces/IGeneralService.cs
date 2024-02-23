using API.Models;
using API.Repositories.Interfaces;

namespace API.Services.Interfaces
{
    public interface IGeneralService<TEntityRepo,TEntity>
    {
        Task<IEnumerable<TEntity>?> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(Guid id, TEntity entity);
        Task<int> DeleteAsync(Guid id);
    }
}
