using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class UpdateElemNumScoreEndpoint
{
    internal static RouteHandlerBuilder MapUpdateElemNumScoreEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateElemNumScoreCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            UpdateElemNumScoreCommandPlayerId requestId = new UpdateElemNumScoreCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateElemNumScoreEndpoint))
            .WithSummary("updates an element number score for a user")
            .WithDescription("updates an element number score for a user")
            .Produces<UpdateElemNumScoreResponse>()
            .MapToApiVersion(1);
    }
}
