using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Abstracts;

namespace CofNTea.Application;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
    void SaveChanges();
}