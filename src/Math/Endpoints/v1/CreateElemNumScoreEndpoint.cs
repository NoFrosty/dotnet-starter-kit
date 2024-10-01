using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class CreateElemNumScoreEndpoint
{
    internal static RouteHandlerBuilder MapCreateElemNumScoreEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (ClaimsPrincipal user, CreateElemNumScoreCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            CreateElemNumScoreCommandPlayerId requestId = new CreateElemNumScoreCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateElemNumScoreEndpoint))
            .WithSummary("creates an element number score for a user")
            .WithDescription("creates an element number score for a user")
            .Produces<CreateElemNumScoreResponse>()
            .MapToApiVersion(1);
    }
}
