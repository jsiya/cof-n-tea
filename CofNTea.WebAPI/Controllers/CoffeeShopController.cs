using System.Net;
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

        if (await _coffeeShopService.CreateCoffeeShop(coffeeShopVm) == HttpStatusCode.OK)
            return StatusCode(201);
        return StatusCode(403);
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
        if(await _coffeeShopService.SoftDeleteCoffeeShopById(id) == HttpStatusCode.OK)
            return StatusCode(204);
        return StatusCode(400);
    }

    [HttpPut("UpdateCategoryById/{id}")]
    public async Task<IActionResult> UpdateCategoryById(int id, [FromBody] CoffeeShopDetailsDto coffeeShopDetailsDto)
    {
        if (await _coffeeShopService.UpdateCoffeeShop(coffeeShopDetailsDto, id) == HttpStatusCode.OK)
            return StatusCode(200);
        return StatusCode(403);
    }
    
}