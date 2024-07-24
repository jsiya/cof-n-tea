using CofNTea.Domain.Entities.Common;

namespace CofNTea.Domain.Entities.Concretes;

public class MenuItem: BaseEntity
{
    public string? ImageUrl { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public int CoffeeShopId { get; set; }

    public virtual CoffeeShop CoffeeShop { get; set; }
}