using Management.Models.Missions;
using Management.Models.Participants;
using Shared.Domain;

namespace Management.Models.Queues;

public class Queue : Entity, IAuditableEntity
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

    public static Queue Create(
        Guid id,
        Participant participant, 
        Mission mission, 
        string metadata)
    {
        return new Queue()
        {
            Id = id,
            ParticipantId = participant.Id,
            MissionId = mission.Id,
            Metadata = metadata,
            Status = QueueStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static Queue Create(Guid id,
                              Guid participantId, 
                              Guid missionId, 
                              string metadata)
    {
        return new Queue()
        {
            Id = id,
            ParticipantId = participantId,
            MissionId = missionId,
            Metadata = metadata,
            Status = QueueStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Complete()
    {
        ModifiedAt = DateTime.UtcNow;
        Status = QueueStatus.Completed;
    }
}
