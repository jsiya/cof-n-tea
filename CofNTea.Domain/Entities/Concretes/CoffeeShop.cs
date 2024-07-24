using CofNTea.Domain.Entities.Common;

namespace CofNTea.Domain.Entities.Concretes;

public class CoffeeShop : BaseEntity
{
    public string? ImageUrl { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public virtual ICollection<MenuItem> MenuItems { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }
}