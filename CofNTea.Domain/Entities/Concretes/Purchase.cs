using CofNTea.Domain.Entities.Common;

namespace CofNTea.Domain.Entities.Concretes;

public class Purchase: BaseEntity
{
    public string AppUserId { get; set; }
    public int CoffeeShopId { get; set; }
    public int Points { get; set; }
    public virtual AppUser AppUser { get; set; }
    public virtual CoffeeShop CoffeeShop { get; set; }
}