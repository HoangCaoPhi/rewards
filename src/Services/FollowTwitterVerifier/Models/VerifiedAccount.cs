using Shared.Domain;

namespace TwitterVerifier.Models;

public class VerifiedAccount : Entity
{
    public Guid UserId { get; private set; }
    public string ScreenName { get; private set; }
    public DateTime VerifiedAt { get; private set; }

    public static VerifiedAccount Create(Guid id,
                                         Guid userId, 
                                         string screenName)
    {
        return new VerifiedAccount()
        {
            Id = id,
            UserId = userId,
            ScreenName = screenName
        };
    }
}
