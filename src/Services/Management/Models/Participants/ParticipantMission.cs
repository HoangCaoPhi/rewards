using Management.Models.Missions;
using Shared.Domain;

namespace Management.Models.Participants;

public class ParticipantMission : Entity
{ 
    public Guid MissionId { get; protected set; }
    public Guid ParticipantId { get; private set; }
    public string VerifierCode { get; private set; }
    public string Configuration { get; private set; }
    public MissionStatus Status { get; private set; }
    public string ProgressMetadata { get; private set; }
    public DateTime AssignedAt { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static ParticipantMission Create(
        Guid missionId,
        Mission mission, 
        Participant participant)
    {
        return new ParticipantMission()
        {
            Id = missionId,
            MissionId = mission.Id,
            ParticipantId = participant.Id,
            Status = MissionStatus.Pending,
            AssignedAt = DateTime.UtcNow
        };
    }

    public void Complete()
    {
        Status = MissionStatus.Completed;
        CompletedAt = DateTime.UtcNow;
    }
}