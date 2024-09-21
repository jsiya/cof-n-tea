using System.Net;
using CofNTea.Application.DTOs.ReviewDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewGetDto>> GetAllReviews();
    Task<ReviewDetailsDto> GetReviewById(int reviewId);
    Task<HttpStatusCode> CreateReview(ReviewDetailsDto reviewDetailsDto);
    Task<HttpStatusCode> SoftDeleteReviewById(int reviewId);
    Task<HttpStatusCode> HardDeleteReviewById(int reviewId);
    Task<HttpStatusCode> UpdateReview(Review review);
}