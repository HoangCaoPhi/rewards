using Shared.Domain;

namespace Management.Models.Verifiers;

public class Verifier : Entity, IAuditableEntity
{
    public string Code { get; private set; }
    public string DbSchema { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Guid CreateBy { get; private set; }
    public Guid? ModifiedBy { get; private set; }
}