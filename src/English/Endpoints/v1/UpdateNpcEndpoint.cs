using FSH.Starter.WebApi.English.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class UpdateNpcEndpoint
{
    internal static RouteHandlerBuilder MapNpcUpdationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateNpcCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateNpcEndpoint))
            .WithSummary("update a npc")
            .WithDescription("update a npc")
            .Produces<UpdateNpcResponse>()
            .MapToApiVersion(1);
    }
}
