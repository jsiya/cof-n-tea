using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Application.DTOs.ReviewDtos;
using CofNTea.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofNTea.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ReviewController: ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost("AddReview")]
    public async Task<IActionResult> CreateReview([FromBody] ReviewDetailsDto reviewDetailsDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _reviewService.CreateReview(reviewDetailsDto);
        return StatusCode(201);
    }

    [HttpGet("AllReviews")]
    public async Task<IActionResult> GetAllReviews()
    {
        var allReviews = await _reviewService.GetAllReviews();
        return Ok(allReviews);
    }
    
    
    [HttpDelete("DeleteReviewById/{id}")]
    public async Task<IActionResult> DeleteReviewById(int id)
    {
        await _reviewService.SoftDeleteReviewById(id);
        return StatusCode(204);
    }

    [HttpPut("UpdateReviewById/{id}")]
    public async Task<IActionResult> UpdateReviewById(int id, [FromBody] ReviewGetDto reviewGetDto)
    { 
        return Ok();
    }
}