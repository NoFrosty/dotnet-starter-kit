using FSH.Starter.WebApi.English.Features.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class DeleteNpcEndpoint
{
    internal static RouteHandlerBuilder MapNpcDeletionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteNpcCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteNpcEndpoint))
            .WithSummary("deletes npc by id")
            .WithDescription("deletes npc by id")
            .Produces(StatusCodes.Status204NoContent)
            .MapToApiVersion(1);
    }
}
