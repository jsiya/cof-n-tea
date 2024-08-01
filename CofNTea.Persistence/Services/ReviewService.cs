using AutoMapper;
using CofNTea.Application;
using CofNTea.Application.DTOs.ReviewDtos;
using CofNTea.Application.Services;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class ReviewService: IReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewGetDto>> GetAllReviews()
    {
        var reviews =  await _unitOfWork.GetRepository<Review>().GetAllAsync();
        var map = _mapper.Map<IList<ReviewGetDto>>(reviews);
        return map;
    }

    public async Task<ReviewDetailsDto> GetReviewById(int reviewId)
    {
        var reviews = await _unitOfWork.GetRepository<Review>().GetByExpressionAsync(c => c.Id == reviewId);
        var review = await reviews.FirstOrDefaultAsync();
        if (review != null)
        {
            var map = _mapper.Map<ReviewDetailsDto>(review);
            return map;
        }
        return null;
    }

    public async Task CreateReview(ReviewDetailsDto reviewDetailsDto)
    {
        var map = _mapper.Map<Review>(reviewDetailsDto);
        await _unitOfWork.GetRepository<Review>().AddAsync(map);
        _unitOfWork.SaveChanges();
    }

    public async Task SoftDeleteReviewById(int reviewId)
    {
        var query = await _unitOfWork.GetRepository<Review>().GetByExpressionAsync(c => c.Id == reviewId);
        var review = await query.FirstOrDefaultAsync();
        if (review != null)
        {
            await _unitOfWork.GetRepository<Review>().SoftDeleteAsync(review);
            _unitOfWork.SaveChanges();
        }
    }

    public async Task HardDeleteReviewById(int reviewId)
    {
        var query = await _unitOfWork.GetRepository<Review>().GetByExpressionAsync(c => c.Id == reviewId);
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
        {
            await _unitOfWork.GetRepository<Review>().HardDeleteAsync(deletedItem);
            _unitOfWork.SaveChanges();
        }
    }

    public Task UpdateReview(Review review)
    {
        throw new NotImplementedException();
    }
}