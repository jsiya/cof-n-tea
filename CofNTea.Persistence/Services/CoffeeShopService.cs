using AutoMapper;
using CofNTea.Application;
using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Application.Services;
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
        var coffeeShops = await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.IsActive == true);
        var map = _mapper.Map<List<CoffeeShopGetDto>>(coffeeShops);
        return map;
    }

    public async Task<CoffeeShopDetailsDto> GetCoffeeShopById(int coffeeShopId)
    {
        var query = await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.Id == coffeeShopId);
        var coffeeShop = await query.FirstOrDefaultAsync();
        if (coffeeShop != null)
        {
            var map = _mapper.Map<CoffeeShopDetailsDto>(coffeeShop);
            return map;
        }
        return null;
    }

    public async Task CreateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto)
    {
        var map = _mapper.Map<CoffeeShop>(coffeeShopDetailsDto);
        await _unitOfWork.GetRepository<CoffeeShop>().AddAsync(map);
        _unitOfWork.SaveChanges();
    }

    public async Task SoftDeleteCoffeeShopById(int coffeeShopId)
    {
        var query = await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.Id == coffeeShopId);
        var coffeeShop = await query.FirstOrDefaultAsync();
        if (coffeeShop != null)
        {
            await _unitOfWork.GetRepository<CoffeeShop>().SoftDeleteAsync(coffeeShop);
            _unitOfWork.SaveChanges();
        }
    }

    public async Task HardDeleteCoffeeShopById(int coffeeShopId)
    {
        var query = await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.Id == coffeeShopId);
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
        {
            await _unitOfWork.GetRepository<CoffeeShop>().HardDeleteAsync(deletedItem);
            _unitOfWork.SaveChanges();
        }
    }

    public async Task UpdateCoffeeShop(CoffeeShopDetailsDto coffeeShopDetailsDto, int id)
    {
        var query = await _unitOfWork.GetRepository<CoffeeShop>().GetByExpressionAsync(c => c.Id == id);
        var coffeeShop = await query.FirstOrDefaultAsync();
        if (coffeeShop is not null)
        {
            _mapper.Map(coffeeShopDetailsDto, coffeeShop);
            await _unitOfWork.GetRepository<CoffeeShop>().UpdateAsync(coffeeShop);
            _unitOfWork.SaveChanges();
        }
    }
}