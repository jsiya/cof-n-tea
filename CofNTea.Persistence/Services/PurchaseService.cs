using System.Net;
using AutoMapper;
using CofNTea.Application;
using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Application.Services;
using CofNTea.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace CofNTea.Persistence.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PurchaseGetDto>> GetAllPurchases()
    {
        var purchases = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(p => p.IsActive == true);
        var map = _mapper.Map<List<PurchaseGetDto>>(purchases);
        return map;
    }

    public async Task<PurchaseDetailsDto> GetPurchaseById(int purchaseId)
    {
        var purchases = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var purchase = await purchases.FirstOrDefaultAsync();
        if (purchase != null)
        {
            var map = _mapper.Map<PurchaseDetailsDto>(purchase);
            return map;
        }

        return null;
    }

    public async Task<HttpStatusCode> CreatePurchase(PurchaseDetailsDto purchaseDetailsDto)
    {
        var map = _mapper.Map<Purchase>(purchaseDetailsDto);
        await _unitOfWork.GetRepository<Purchase>().AddAsync(map);
        _unitOfWork.SaveChanges();
        
        throw new NotImplementedException();
    }

    public async Task<HttpStatusCode> SoftDeletePurchaseById(int purchaseId)
    {
        var query = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var purchase = await query.FirstOrDefaultAsync();
        if (purchase != null)
        {
            await _unitOfWork.GetRepository<Purchase>().SoftDeleteAsync(purchase);
            _unitOfWork.SaveChanges();
        }
        
        throw new NotImplementedException();
    }

    public async Task<HttpStatusCode> HardDeletePurchaseById(int purchaseId)
    {
        var query = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
        {
            await _unitOfWork.GetRepository<Purchase>().HardDeleteAsync(deletedItem);
            _unitOfWork.SaveChanges();
        }
        
        throw new NotImplementedException();
    }

    public Task<HttpStatusCode> UpdatePurchase(Purchase purchase)
    {
        throw new NotImplementedException();
    }
}