using CofNTea.Domain.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace CofNTea.Domain.Entities.Concretes;

public class AppUser : IdentityUser, IBaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int Points { get; set; }
    public virtual ICollection<Reward> Rewards { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}