using Shared.Domain;

namespace Management.Models.Participants;

public class Participant : Entity, IAuditableEntity
{
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool HasVerified { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid CreateBy { get; private set; }

    public DateTime? ModifiedAt { get; private set; }

    public Guid? ModifiedBy { get; private set; }
}
