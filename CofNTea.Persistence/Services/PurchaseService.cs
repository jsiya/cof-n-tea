using CofNTea.Application;
using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Application.Services;
using CofNTea.Application.Utilities.AutoMapper;
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
        var purchases = await _unitOfWork.GetRepository<Purchase>().GetAllAsync();
        var map = _mapper.Map<PurchaseGetDto, Purchase>((IList<Purchase>)purchases);
        return map;
    }

    public async Task<PurchaseDetailsDto> GetPurchaseById(int purchaseId)
    {
        var purchases = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var purchase = await purchases.FirstOrDefaultAsync();
        if (purchase != null)
        {
            var map = _mapper.Map<PurchaseDetailsDto, Purchase>(purchase);
            return map;
        }

        return null;
    }

    public async Task CreatePurchase(PurchaseDetailsDto purchaseDetailsDto)
    {
        var map = _mapper.Map<Purchase, PurchaseDetailsDto>(purchaseDetailsDto);
        await _unitOfWork.GetRepository<Purchase>().AddAsync(map);
        _unitOfWork.SaveChanges();
    }

    public async Task SoftDeletePurchaseById(int purchaseId)
    {
        var query = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var purchase = await query.FirstOrDefaultAsync();
        if (purchase != null)
        {
            await _unitOfWork.GetRepository<Purchase>().SoftDeleteAsync(purchase);
            _unitOfWork.SaveChanges();
        }
    }

    public async Task HardDeletePurchaseById(int purchaseId)
    {
        var query = await _unitOfWork.GetRepository<Purchase>().GetByExpressionAsync(c => c.Id == purchaseId);
        var deletedItem = await query.FirstOrDefaultAsync();
        if (deletedItem is not null)
        {
            await _unitOfWork.GetRepository<Purchase>().HardDeleteAsync(deletedItem);
            _unitOfWork.SaveChanges();
        }
    }

    public Task UpdatePurchase(Purchase purchase)
    {
        throw new NotImplementedException();
    }
}