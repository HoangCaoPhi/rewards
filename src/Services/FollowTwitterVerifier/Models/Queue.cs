namespace TwitterVerifier.Models;

public class Queue
{
    public Guid ParticipantId { get; private set; }
    public Guid MissionId { get; private set; }
    public string Configuration { get; private set; }
    public string Metadata { get; private set; }
    public QueueStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid CreateBy { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Guid? ModifiedBy { get; private set; }
}
