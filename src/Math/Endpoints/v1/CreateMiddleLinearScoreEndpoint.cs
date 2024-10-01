using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class CreateMiddleLinearScoreEndpoint
{
    internal static RouteHandlerBuilder MapCreateMiddleLinearScoreEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (ClaimsPrincipal user, CreateScoreCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            CreateScoreCommandPlayerId requestId = new CreateScoreCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateMiddleLinearScoreEndpoint))
            .WithSummary("creates an element number score for a user")
            .WithDescription("creates an element number score for a user")
            .Produces<CreateScoreResponse>()
            .MapToApiVersion(1);
    }
}
