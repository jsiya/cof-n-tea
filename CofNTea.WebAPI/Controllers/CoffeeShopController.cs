using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofNTea.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeeShopController: ControllerBase
{
    private readonly ICoffeeShopService _coffeeShopService;

    public CoffeeShopController(ICoffeeShopService coffeeShopService)
    {
        _coffeeShopService = coffeeShopService;
    }

    [HttpPost("AddCoffeeShop")]
    public async Task<IActionResult> CreateCoffeeShop([FromBody] CoffeeShopDetailsDto coffeeShopVm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _coffeeShopService.CreateCoffeeShop(coffeeShopVm);
        return StatusCode(201);
    }

    [HttpGet("AllCoffeeShops")]
    public async Task<IActionResult> GetAllCoffeeShops()
    {
        var allCoffeeShops = await _coffeeShopService.GetAllCoffeeShops();
        return Ok(allCoffeeShops);
    }
    
    
    [HttpDelete("DeleteCoffeeShopById/{id}")]
    public async Task<IActionResult> DeleteCoffeeShop(int id)
    {
        await _coffeeShopService.SoftDeleteCoffeeShopById(id);
        return StatusCode(204);
    }

    [HttpPut("UpdateCategoryById/{id}")]
    public async Task<IActionResult> UpdateCategoryById(int id, [FromBody] CoffeeShopDetailsDto coffeeShopDetailsDto)
    {
        await _coffeeShopService.UpdateCoffeeShop(coffeeShopDetailsDto, id);
        return Ok();
    }
    
}