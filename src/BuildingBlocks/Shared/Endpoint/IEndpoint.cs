using Microsoft.AspNetCore.Routing;

namespace Shared.Endpoint;
public interface IEndpoint
{
    string EndpointName { get; }
    void MapEndpoint(IEndpointRouteBuilder endpoint);
}
