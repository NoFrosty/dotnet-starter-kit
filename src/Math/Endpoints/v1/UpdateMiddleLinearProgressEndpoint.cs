using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class UpdateMiddleLinearProgressEndpoint
{
    internal static RouteHandlerBuilder MapUpdateMiddleLinearProgressEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/", async (ClaimsPrincipal user, UpdateMiddleLinearProgressCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }
            UpdateMiddleLinearProgressCommandPlayerId requestId = new UpdateMiddleLinearProgressCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(UpdateMiddleLinearProgressEndpoint))
            .WithSummary("updates an element number progress for a user")
            .WithDescription("updates an element number progress for a user")
            .Produces<UpdateMiddleLinearProgressResponse>()
            .MapToApiVersion(1);
    }
}
