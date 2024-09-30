using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class CreateProgressEndpoint
{
    internal static RouteHandlerBuilder MapProgressCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (ClaimsPrincipal user, CreateProgressCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            CreateProgressCommandPlayerId requestId = new CreateProgressCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateProgressEndpoint))
            .WithSummary("creates a progress item for a user")
            .WithDescription("creates a progress item for a user")
            .Produces<CreateProgressResponse>()
            .MapToApiVersion(1);
    }
}
