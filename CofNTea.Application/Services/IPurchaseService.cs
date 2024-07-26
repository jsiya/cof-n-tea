using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IPurchaseService
{
    Task<IEnumerable<PurchaseGetDto>> GetAllPurchases();
    Task<PurchaseDetailsDto> GetPurchaseById(int purchaseId);
    Task CreatePurchase(PurchaseDetailsDto purchaseDetailsDto);
    Task SoftDeletePurchaseById(int purchaseId);
    Task HardDeletePurchaseById(int purchaseId);
    Task UpdatePurchase(Purchase purchase);
}