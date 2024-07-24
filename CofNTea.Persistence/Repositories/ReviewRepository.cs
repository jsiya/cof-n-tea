using CofNTea.Application.Repositories;
using CofNTea.Domain.Entities.Concretes;
using CofNTea.Persistence.DbContexts;

namespace CofNTea.Persistence.Repositories;

public class ReviewRepository: GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }
}