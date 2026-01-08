namespace ProjectCore.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; protected set; }
}