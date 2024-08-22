using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class GetHeartEndpoint
{
    internal static RouteHandlerBuilder MapGetHeartEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetHeartRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetHeartEndpoint))
            .WithSummary("gets heart amount by user id")
            .WithDescription("gets heart amount by user id")
            .Produces<GetHeartResponse>()
            .MapToApiVersion(1);
    }
}
