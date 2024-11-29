using Management.Models.Rewards;
using Shared.Domain;

namespace Management.Models.Participants;

public class ParticipantReward : Entity
{
    public Guid ParticipantId { get; private set; }
    public RewardType RewardType { get; private set; }
    public float Amount { get; private set; }
    public DateTime UpdatedAt { get; private set; }


    public static ParticipantReward Create(
        Guid id,
        Participant participant, 
        RewardType rewardType, 
        float amount)
    {
        return new ParticipantReward()
        {
            Id = id,
            ParticipantId = participant.Id,
            RewardType = rewardType,
            Amount = amount
        };
    }

    public void UpdateAmount(float amount)
    {
        Amount += amount;
        UpdatedAt = DateTime.UtcNow;
    }
}