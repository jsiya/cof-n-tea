using System.Net;
using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofNTea.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MenuItemController: ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpPost("AddMenuItem")]
    public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemDetailsDto menuItemDetailsDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _menuItemService.CreateMenuItem(menuItemDetailsDto);
        return StatusCode(201);
    }

    [HttpGet("AllMenuItems")]
    public async Task<IActionResult> GetAllMenuItems()
    {
        var allMenuItems = await _menuItemService.GetAllMenuItems();
        return Ok(allMenuItems);
    }
    
    
    [HttpDelete("DeleteMenuItemById/{id}")]
    public async Task<IActionResult> DeleteMenuItemById(int id)
    {
        await _menuItemService.SoftDeleteMenuItemById(id);
        return StatusCode(204);
    }

    [HttpPut("UpdateMenuItemById/{id}")]
    public async Task<IActionResult> UpdateMenuItemById(int id, [FromBody] MenuItemDetailsDto menuItemDetailsDto)
    {
        var result = await _menuItemService.UpdateMenuItem(menuItemDetailsDto, id);
        return StatusCode((int)result);
    }
}