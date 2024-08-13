using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class GetNpcEndpoint
{
    internal static RouteHandlerBuilder MapGetNpcEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetNpcRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetNpcEndpoint))
            .WithSummary("gets npc by id")
            .WithDescription("gets npc by id")
            .Produces<GetNpcResponse>()
            .MapToApiVersion(1);
    }
}
