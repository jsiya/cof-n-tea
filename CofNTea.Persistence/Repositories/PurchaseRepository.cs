using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;

public class PurchaseRepository: GenericRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(AppDbContext context) : base(context)
    {
    }
}