using System.Net;
using CofNTea.Application.DTOs.CoffeeShopDtos;

namespace CofNTea.Application.Services;
public interface ICoffeeShopService
{
    Task<IEnumerable<CoffeeShopGetDto>> GetAllCoffeeShops();
    Task<CoffeeShopDetailsDto> GetCoffeeShopById(int coffeeShopId);
    Task<HttpStatusCode> CreateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto);
    Task<HttpStatusCode> SoftDeleteCoffeeShopById(int coffeeShopId);
    Task<HttpStatusCode> HardDeleteCoffeeShopById(int coffeeShopId);
    Task<HttpStatusCode> UpdateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto, int id);
}