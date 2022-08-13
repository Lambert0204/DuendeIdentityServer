using InternalApi.Domain.Entities;
using InternalApi.Infrastructure.Context;
using InternalApi.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InternalApi.Infrastructure.Repository;
public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    public RepositoryBase(InternalContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.SingleOrDefaultAsync(expression);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToListAsync();
    }

    public Task<List<T>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }
}