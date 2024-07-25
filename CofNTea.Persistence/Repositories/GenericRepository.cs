using System.Linq.Expressions;
using CofNTea.Application.Repositories;
using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Abstracts;
using CofNTea.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T: class, IBaseEntity
{
    protected readonly AppDbContext _context;
    protected DbSet<T> _table;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table.ToList();
    }

    public async Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return _table.Where(expression);
    }
    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _table.AddRangeAsync(entities);
    }
    
    public async Task UpdateAsync(T entity)
    {
        _table.Update(entity);
    }
    
    public async Task DeleteAsync(T entity)
    {
        _table.Remove(entity);
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.IsActive = false;
        _table.Update(entity);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}