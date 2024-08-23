using FSH.Framework.Infrastructure.Auth.Policy;
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
            .WithSummary("deletes bean amount for user")
            .WithDescription("deletes bean amount for user")
            .Produces(StatusCodes.Status204NoContent)
            .MapToApiVersion(1)
            .RequirePermission("Permissions.Beans.Delete");
    }
}
