using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class CreateHeartEndpoint
{
    internal static RouteHandlerBuilder MapHeartCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (ClaimsPrincipal user, CreateHeartCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            CreateHeartCommandPlayerId requestId = new CreateHeartCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateHeartEndpoint))
            .WithSummary("creates a heart counter for a user")
            .WithDescription("creates a heart counter for a user")
            .Produces<CreateHeartResponse>()
            .MapToApiVersion(1);
    }
}
