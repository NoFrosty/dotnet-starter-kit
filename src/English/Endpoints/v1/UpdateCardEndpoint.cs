using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class UpdateCardEndpoint
{
    internal static RouteHandlerBuilder MapCardUpdationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateCardCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }

            UpdateCardCommandPlayerId requestId = new UpdateCardCommandPlayerId(new Guid(userId), request);

            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateCardEndpoint))
            .WithSummary("updates card collection for a user")
            .WithDescription("updates card collection for a user")
            .Produces<UpdateCardResponse>()
            .MapToApiVersion(1);
    }
}
