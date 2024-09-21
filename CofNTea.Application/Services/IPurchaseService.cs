using System.Net;
using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IPurchaseService
{
    Task<IEnumerable<PurchaseGetDto>> GetAllPurchases();
    Task<PurchaseDetailsDto> GetPurchaseById(int purchaseId);
    Task<HttpStatusCode> CreatePurchase(PurchaseDetailsDto purchaseDetailsDto);
    Task<HttpStatusCode> SoftDeletePurchaseById(int purchaseId);
    Task<HttpStatusCode> HardDeletePurchaseById(int purchaseId);
    Task<HttpStatusCode> UpdatePurchase(Purchase purchase);
}