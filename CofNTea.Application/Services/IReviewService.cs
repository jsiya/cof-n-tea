using CofNTea.Application.DTOs.ReviewDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewGetDto>> GetAllReviews();
    Task<ReviewDetailsDto> GetReviewById(int reviewId);
    Task CreateReview(ReviewDetailsDto reviewDetailsDto);
    Task SoftDeleteReviewById(int reviewId);
    Task HardDeleteReviewById(int reviewId);
    Task UpdateReview(Review review);
}