using System.Net;
using CofNTea.Application.DTOs.RewardDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IRewardService
{
    Task<IEnumerable<RewardDetailsDto>> GetAllRewards();
    Task<RewardDetailsDto> GetRewardById(int rewardId);
    Task<HttpStatusCode> CreateReward(RewardDetailsDto rewardDetailsDto);
    Task<HttpStatusCode> SoftDeleteRewardById(int rewardId);
    Task<HttpStatusCode> HardDeleteRewardById(int rewardId);
    Task<HttpStatusCode> UpdateReward(Reward reward);
}