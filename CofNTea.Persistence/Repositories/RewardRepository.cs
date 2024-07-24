using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;

public class RewardRepository: GenericRepository<Reward>, IRewardRepository
{
    public RewardRepository(AppDbContext context) : base(context)
    {
    }
}