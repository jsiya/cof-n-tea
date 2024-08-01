using AutoMapper;
using CofNTea.Application;
using CofNTea.Application.DTOs.RewardDtos;
using CofNTea.Application.Services;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class RewardService: IRewardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RewardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RewardDetailsDto>> GetAllRewards()
    {
        var rewards =  await _unitOfWork.GetRepository<Reward>().GetAllAsync();
        var map = _mapper.Map<List<RewardDetailsDto>>(rewards);
        return map;
    }

    public async Task<RewardDetailsDto> GetRewardById(int rewardId)
    {
        var rewards = await _unitOfWork.GetRepository<Reward>().GetByExpressionAsync(c => c.Id == rewardId);
        var reward = await rewards.FirstOrDefaultAsync();
        if (reward != null)
        {
            var map = _mapper.Map<RewardDetailsDto>(reward);
            return map;
        }
        return null;
    }

    public async Task CreateReward(RewardDetailsDto rewardDetailsDto)
    {
        var map = _mapper.Map<Reward>(rewardDetailsDto);
        await _unitOfWork.GetRepository<Reward>().AddAsync(map);
        _unitOfWork.SaveChanges();
    }

    public async Task SoftDeleteRewardById(int rewardId)
    {
        var query = await _unitOfWork.GetRepository<Reward>().GetByExpressionAsync(c => c.Id == rewardId);
        var reward = await query.FirstOrDefaultAsync();
        if (reward != null)
        {
            await _unitOfWork.GetRepository<Reward>().SoftDeleteAsync(reward);
            _unitOfWork.SaveChanges();
        }
    }

    public async Task HardDeleteRewardById(int rewardId)
    {
        var query = await _unitOfWork.GetRepository<Reward>().GetByExpressionAsync(c => c.Id == rewardId);
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
        {
            await _unitOfWork.GetRepository<Reward>().HardDeleteAsync(deletedItem);
            _unitOfWork.SaveChanges();
        }
    }

    public Task UpdateReward(Reward reward)
    {
        throw new NotImplementedException();
    }
}