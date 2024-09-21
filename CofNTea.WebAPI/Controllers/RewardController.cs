using CofNTea.Application.DTOs.RewardDtos;
using CofNTea.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofNTea.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RewardController: ControllerBase
{
    private readonly IRewardService _rewardService;

    public RewardController(IRewardService rewardService)
    {
        _rewardService = rewardService;
    }

    [HttpPost("AddReward")]
    public async Task<IActionResult> CreateReward([FromBody] RewardDetailsDto rewardDetailsDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _rewardService.CreateReward(rewardDetailsDto);
        return StatusCode(201);
    }

    [HttpGet("AllRewards")]
    public async Task<IActionResult> GetAllRewards()
    {
        var allRewards = await _rewardService.GetAllRewards();
        return Ok(allRewards);
    }
    
    
    [HttpDelete("DeleteRewardById/{id}")]
    public async Task<IActionResult> DeleteRewardById(int id)
    {
        await _rewardService.SoftDeleteRewardById(id);
        return StatusCode(204);
    }

    [HttpPut("UpdateRewardById/{id}")]
    public async Task<IActionResult> UpdateRewardById(int id, [FromBody] RewardDetailsDto rewardDetailsDto)
    { 
        return Ok();
    }
}