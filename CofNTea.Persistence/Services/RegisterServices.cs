using CofNTea.Application;
using CofNTea.Application.Repositories;
using CofNTea.Application.Services;
using CofNTea.Persistence.DbContexts;
using CofNTea.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CofNTea.Persistence.Services;

public static class RegisterServices
{
    public static void AddPersistenceRegister(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(option =>
        {
            ConfigurationBuilder configurationBuilder = new();
            var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();

            option.UseLazyLoadingProxies()
                .UseSqlServer(builder.GetConnectionString("Default"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IRewardRepository, RewardRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<ICoffeeShopService, CoffeeShopService>();
    }
    
}