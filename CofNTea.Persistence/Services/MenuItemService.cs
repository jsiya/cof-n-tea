using System.Net;
using AutoMapper;
using CofNTea.Application;
using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Application.Services;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class MenuItemService:IMenuItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MenuItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MenuItemGetDto>> GetAllMenuItems()
    {
        var menuItems =  await _unitOfWork.GetRepository<MenuItem>().GetByExpressionAsync(m => m.IsActive == true);
        var map = _mapper.Map<IList<MenuItemGetDto>>(menuItems);
        return map;
    }

    public async Task<MenuItemDetailsDto> GetMenuItemById(int menuItemId)
    {
        var menuItems = await _unitOfWork.GetRepository<MenuItem>().GetByExpressionAsync(m => m.Id == menuItemId && m.IsActive == true);
        var menuItem = await menuItems.FirstOrDefaultAsync();
        if (menuItem != null)
        {
            var map = _mapper.Map<MenuItemDetailsDto>(menuItem);
            return map;
        }
        return null;
    }

    public async Task<HttpStatusCode> CreateMenuItem(MenuItemDetailsDto menuItemDetailsDto)
    {
        try
        {
            var map = _mapper.Map<MenuItem>(menuItemDetailsDto);
            await _unitOfWork.GetRepository<MenuItem>().AddAsync(map);
            _unitOfWork.SaveChanges();
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public async Task<HttpStatusCode> SoftDeleteMenuItemById(int menuItemId)
    {
        try
        {
            var query = await _unitOfWork.GetRepository<MenuItem>().GetByExpressionAsync(c => c.Id == menuItemId);
            var menuItem = await query.FirstOrDefaultAsync();
            if (menuItem != null)
            {
                await _unitOfWork.GetRepository<MenuItem>().SoftDeleteAsync(menuItem);
                _unitOfWork.SaveChanges();
            }

            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public async Task<HttpStatusCode> HardDeleteMenuItemById(int menuItemId)
    {
        try
        {
            var query = await _unitOfWork.GetRepository<MenuItem>().GetByExpressionAsync(c => c.Id == menuItemId);
            var deletedItem = await query.FirstOrDefaultAsync();
            if (deletedItem is not null)
            {
                await _unitOfWork.GetRepository<MenuItem>().HardDeleteAsync(deletedItem);
                _unitOfWork.SaveChanges();
            }
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public async Task<HttpStatusCode> UpdateMenuItem(MenuItemDetailsDto menuItemDetailsDto, int id)
    {
        var query = await _unitOfWork.GetRepository<MenuItem>().GetByExpressionAsync(m => m.Id == id && m.IsActive == true);
        var menuItem = await query.FirstOrDefaultAsync();
        if (menuItem is not null)
        {
            _mapper.Map(menuItemDetailsDto, menuItem);
            await _unitOfWork.GetRepository<MenuItem>().UpdateAsync(menuItem);
            _unitOfWork.SaveChanges();
            return HttpStatusCode.OK;
        }

        return HttpStatusCode.Forbidden;
    }
}