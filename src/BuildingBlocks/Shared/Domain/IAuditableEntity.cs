namespace Shared.Domain;
public interface IAuditableEntity
{
    public DateTime CreatedAt { get; }
    public Guid CreateBy { get; }

    public DateTime? ModifiedAt { get; }
    public Guid? ModifiedBy { get; }
}
