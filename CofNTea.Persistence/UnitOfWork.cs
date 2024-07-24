using CofNTea.Application;
using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Abstracts;
using CofNTea.Persistence.DbContexts;
using CofNTea.Persistence.Repositories;

namespace CofNTea.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new GenericRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}