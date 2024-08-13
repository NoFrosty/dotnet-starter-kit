using FSH.Starter.WebApi.English.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class CreateNpcEndpoint
{
    internal static RouteHandlerBuilder MapNpcCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (CreateNpcCommand request, ISender mediator) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateNpcEndpoint))
            .WithSummary("creates a npc")
            .WithDescription("creates a npc")
            .Produces<CreateNpcResponse>()
            .MapToApiVersion(1);
    }
}
