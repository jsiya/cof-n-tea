using CofNTea.Domain.Entities.Abstracts;

namespace CofNTea.Domain.Entities.Common;

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}