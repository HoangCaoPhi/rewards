using Management.Models.Categories;
using Shared.Domain;

namespace Management.Models.Missions;

public class Mission : Entity, IAuditableEntity
{
    public string Title { get; private set; }
    public string? Subtitle { get; private set; }
    public MissionType Type { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public string VerifierCode { get; private set; }
    public string InputSchema { get; private set; }
    public string Metadata { get; private set; }
    public string MetadataSchema { get; private set; }

    public string Rewards { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public Guid CreateBy { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Guid? ModifiedBy { get; private set; }
}
