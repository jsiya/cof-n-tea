using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface ICoffeeShopService
{
    Task<IEnumerable<CoffeeShopGetDto>> GetAllCoffeeShops();
    Task<IQueryable<CoffeeShop>> GetCoffeeShopById(int coffeeShopId);
    Task CreateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto);
    Task SoftDeleteCoffeeShopById(int coffeeShopId);
    Task HardDeleteCoffeeShopById(int coffeeShopId);
    Task UpdateCoffeeShop(CoffeeShop appUser);
}