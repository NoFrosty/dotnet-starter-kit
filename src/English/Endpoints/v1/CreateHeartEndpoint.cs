using FSH.Starter.WebApi.English.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class CreateHeartEndpoint
{
    internal static RouteHandlerBuilder MapHeartCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (CreateHeartCommand request, ISender mediator) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateHeartEndpoint))
            .WithSummary("creates a heart counter for a user")
            .WithDescription("creates a heart counter for a user")
            .Produces<CreateHeartResponse>()
            .MapToApiVersion(1);
    }
}
