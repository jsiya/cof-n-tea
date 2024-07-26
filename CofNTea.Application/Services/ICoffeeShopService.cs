using CofNTea.Application.DTOs.CoffeeShopDtos;

namespace CofNTea.Application.Services;
public interface ICoffeeShopService
{
    Task<IEnumerable<CoffeeShopGetDto>> GetAllCoffeeShops();
    Task<CoffeeShopDetailsDto> GetCoffeeShopById(int coffeeShopId);
    Task CreateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto);
    Task SoftDeleteCoffeeShopById(int coffeeShopId);
    Task HardDeleteCoffeeShopById(int coffeeShopId);
    Task UpdateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto, int id);
}