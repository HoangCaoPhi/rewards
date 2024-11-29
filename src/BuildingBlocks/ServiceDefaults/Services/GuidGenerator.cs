using Shared;

namespace ServiceDefaults.Services;
public class GuidGenerator : IGuidGenerator
{
    public Guid NewGuid()
    {
        return Guid.CreateVersion7();
    }
}
