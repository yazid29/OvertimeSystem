using API.Data;
using API.Models;

namespace API.Contracts;

public interface IGeneralRepository<TEntity>
{
    //OvertimeServiceDbContext GetContext();
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task ChangeTrackingAsync();
}