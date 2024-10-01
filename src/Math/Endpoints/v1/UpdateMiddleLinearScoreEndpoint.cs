using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class UpdateMiddleLinearScoreEndpoint
{
    internal static RouteHandlerBuilder MapUpdateMiddleLinearScoreEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateScoreCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            UpdateScoreCommandPlayerId requestId = new UpdateScoreCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateMiddleLinearScoreEndpoint))
            .WithSummary("updates an element number score for a user")
            .WithDescription("updates an element number score for a user")
            .Produces<UpdateScoreResponse>()
            .MapToApiVersion(1);
    }
}
