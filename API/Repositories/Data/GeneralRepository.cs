using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Repositories;

public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
{
    public readonly OvertimeServiceDbContext _context;

    protected GeneralRepository(OvertimeServiceDbContext context)
    {
        _context = context;
    }
    //public OvertimeServiceDbContext GetContext()
    //{
    //    return _context;
    //}
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        _context.ChangeTracker.Clear();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    public Task ChangeTrackingAsync()
    {
        _context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }
}