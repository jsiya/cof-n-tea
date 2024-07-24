using CofNTea.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.DbContexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public virtual DbSet<CoffeeShop> CoffeeShops { get; set; }
    public virtual DbSet<MenuItem> MenuItems { get; set; }
    public virtual DbSet<Purchase> Purchases { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Reward> Rewards { get; set; }

}