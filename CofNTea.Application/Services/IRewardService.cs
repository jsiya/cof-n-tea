using CofNTea.Application.DTOs.RewardDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IRewardService
{
    Task<IEnumerable<RewardDetailsDto>> GetAllRewards();
    Task<RewardDetailsDto> GetRewardById(int rewardId);
    Task CreateReward(RewardDetailsDto rewardDetailsDto);
    Task SoftDeleteRewardById(int rewardId);
    Task HardDeleteRewardById(int rewardId);
    Task UpdateReward(Reward reward);
}