using System.Linq.Expressions;
using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;

public class AppUserRepository: GenericRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(AppDbContext context) : base(context)
    {
    }
}