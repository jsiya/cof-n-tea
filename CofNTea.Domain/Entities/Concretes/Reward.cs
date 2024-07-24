using CofNTea.Domain.Entities.Common;

namespace CofNTea.Domain.Entities.Concretes;

public class Reward: BaseEntity
{
    public string Name { get; set; }
    public DateTime RedeemedDate { get; set; }
    public int PointsUsed { get; set; }
}