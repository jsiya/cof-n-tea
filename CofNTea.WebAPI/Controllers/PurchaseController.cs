using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofNTea.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PurchaseController: ControllerBase
{
    private readonly IPurchaseService _purchaseService;
    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }
    
    
    [HttpPost("AddPurchase")]
    public async Task<IActionResult> CreatePurchase([FromBody] PurchaseDetailsDto purchaseDetailsDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _purchaseService.CreatePurchase(purchaseDetailsDto);
        return StatusCode(201);
    }

    [HttpGet("AllPurchases")]
    public async Task<IActionResult> GetAllPurchases()
    {
        var allPurchases = await _purchaseService.GetAllPurchases();
        return Ok(allPurchases);
    }
    
    
    [HttpDelete("DeletePurchaseById/{id}")]
    public async Task<IActionResult> DeletePurchaseById(int id)
    {
        await _purchaseService.SoftDeletePurchaseById(id);
        return StatusCode(204);
    }

    [HttpPut("UpdatePurchaseById/{id}")]
    public async Task<IActionResult> UpdatePurchaseById(int id, [FromBody] PurchaseGetDto purchaseGetDto)
    { 
        return Ok();
    }
    
}