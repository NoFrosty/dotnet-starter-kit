using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class UpdateHeartEndpoint
{
    internal static RouteHandlerBuilder MapHeartUpdationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateHeartCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }

            UpdateHeartCommandPlayerId requestId = new UpdateHeartCommandPlayerId(new Guid(userId), request);

            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateHeartEndpoint))
            .WithSummary("updates a heart counter for a user")
            .WithDescription("updates a heart counter for a user")
            .Produces<UpdateHeartResponse>()
            .MapToApiVersion(1);
    }
}
