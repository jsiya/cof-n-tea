using CofNTea.Application;
using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Application.Services;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class CoffeeShopService: ICoffeeShopService
{
    private IUnitOfWork _unitOfWork;

    public CoffeeShopService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CoffeeShop>> GetAllCoffeeShops()
    {
        return await _unitOfWork.GetRepository<CoffeeShop>().GetAllAsync();
    }

    public async Task<IQueryable<CoffeeShop>> GetCoffeeShopById(int coffeeShopId)
    {
        return await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.Id == coffeeShopId);
    }

    public async Task CreateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto)
    {
        var coffeeShop = new CoffeeShop()
        {
            Name = coffeeShopDetailsDto.Name,
            Address = coffeeShopDetailsDto.Address,
            ImageUrl = coffeeShopDetailsDto.ImageUrl,
            Latitude = coffeeShopDetailsDto.Latitude,
            Longitude = coffeeShopDetailsDto.Longitude
        };
        await _unitOfWork.GetRepository<CoffeeShop>().AddAsync(coffeeShop);
         _unitOfWork.SaveChanges();
    }

    public async Task SoftDeleteCoffeeShopById(int coffeeShopId)
    {
        var coffeeShop = _unitOfWork.GetRepository<CoffeeShop>()
            .GetByExpressionAsync(c => c.Id == coffeeShopId)
            .Result
            .FirstOrDefaultAsync()
            .Result;
        if (coffeeShop != null)
            coffeeShop.IsActive = false;
        _unitOfWork.SaveChanges();
    }

    public async Task HardDeleteCoffeeShopById(int coffeeShopId)
    {
        var query =  _unitOfWork.GetRepository<CoffeeShop>()
                                                    .GetByExpressionAsync(c => c.Id == coffeeShopId)
                                                    .Result;
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
            await _unitOfWork.GetRepository<CoffeeShop>().DeleteAsync(deletedItem);
        _unitOfWork.SaveChanges();
    }

    public Task UpdateCoffeeShop(CoffeeShop appUser)
    {
        throw new NotImplementedException();
    }
}