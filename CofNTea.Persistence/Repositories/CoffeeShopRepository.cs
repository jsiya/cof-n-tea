using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;


public class CoffeeShopRepository: GenericRepository<CoffeeShop>, ICoffeeShopRepository
{
    public CoffeeShopRepository(AppDbContext context) : base(context)
    {
    }
}