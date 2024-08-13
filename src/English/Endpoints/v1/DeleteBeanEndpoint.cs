using FSH.Starter.WebApi.English.Features.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class DeleteBeanEndpoint
{
    internal static RouteHandlerBuilder MapBeanDeletionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteBeanCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteBeanEndpoint))
            .WithSummary("deletes a bean")
            .WithDescription("deletes a bean")
            .Produces(StatusCodes.Status204NoContent)
            .MapToApiVersion(1);
    }
}
