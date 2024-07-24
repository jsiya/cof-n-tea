using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Services;

public interface IAppUserService
{
    Task<IEnumerable<AppUser>> GetAllAppUsers();
    Task<AppUser> GetAppUserById();
    Task<bool> CreateAppUser(AppUser createAppUserVm);
    Task<bool> SoftDeleteAppUserById(Guid appUserId);
    Task<bool> HardDeleteAppUserById(Guid appUserId);
    Task<bool> UpdateAppUser(AppUser appUser);
}