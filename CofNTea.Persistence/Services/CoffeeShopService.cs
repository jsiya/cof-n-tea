using CofNTea.Application;
using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Application.Services;
using CofNTea.Application.Utilities.AutoMapper;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class CoffeeShopService: ICoffeeShopService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CoffeeShopService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CoffeeShopGetDto>> GetAllCoffeeShops()
    {
        var coffeeShops =  await _unitOfWork.GetRepository<CoffeeShop>().GetAllAsync();

        IEnumerable<CoffeeShopGetDto> coffeeShopGetDtos = new List<CoffeeShopGetDto>();

        var map = _mapper.Map<CoffeeShopGetDto, CoffeeShop>((IList<CoffeeShop>)coffeeShops);
        return map;
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