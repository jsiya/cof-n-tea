using System.Linq.Expressions;
using CofNTea.Domain.Entities.Abstracts;

namespace CofNTea.Application.Repositories;

public interface IGenericRepository<T> where T: class, IBaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task HardDeleteAsync(T entity);
    Task SoftDeleteAsync(T entity); 
    Task SaveChangeAsync();
}