using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;

public class MenuItemRepository: GenericRepository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(AppDbContext context) : base(context)
    {
    }
}