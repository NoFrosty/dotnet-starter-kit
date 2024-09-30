using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class UpdateProtressEndpoint
{
    internal static RouteHandlerBuilder MapProgressUpdationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateProgressCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }

            UpdateProgressCommandPlayerId requestId = new UpdateProgressCommandPlayerId(new Guid(userId), request);

            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateProtressEndpoint))
            .WithSummary("updates a progress item for a user")
            .WithDescription("updates a progress item for a user")
            .Produces<UpdateProgressResponse>()
            .MapToApiVersion(1);
    }
}
