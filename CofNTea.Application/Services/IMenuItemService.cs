using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IMenuItemService
{
    Task<IEnumerable<MenuItemGetDto>> GetAllMenuItems();
    Task<MenuItemDetailsDto> GetMenuItemById(int menuItemId);
    Task CreateMenuItem(MenuItemDetailsDto menuItemDetailsDto);
    Task SoftDeleteMenuItemById(int menuItemId);
    Task HardDeleteMenuItemById(int menuItemId);
    Task UpdateMenuItem(MenuItem menuItem);
}