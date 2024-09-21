using System.Net;
using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IMenuItemService
{
    Task<IEnumerable<MenuItemGetDto>> GetAllMenuItems();
    Task<MenuItemDetailsDto> GetMenuItemById(int menuItemId);
    Task<HttpStatusCode> CreateMenuItem(MenuItemDetailsDto menuItemDetailsDto);
    Task<HttpStatusCode> SoftDeleteMenuItemById(int menuItemId);
    Task<HttpStatusCode> HardDeleteMenuItemById(int menuItemId);
    Task<HttpStatusCode>  UpdateMenuItem(MenuItemDetailsDto menuItemDetailsDto, int id);
}