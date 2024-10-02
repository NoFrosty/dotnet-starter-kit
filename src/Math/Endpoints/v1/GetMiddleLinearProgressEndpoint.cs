using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class GetMiddleLinearProgressEndpoint
{
    internal static RouteHandlerBuilder MapGetMiddleLinearProgressEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/", async (ClaimsPrincipal user, ISender mediator) =>
            {
                if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException();
                }
                var response = await mediator.Send(new GetMiddleLinearProgressRequest(new Guid(userId)));
                return Results.Ok(response);
            })
            .WithName(nameof(GetMiddleLinearProgressEndpoint))
            .WithSummary("gets element number progress by user id")
            .WithDescription("gets element number progress by user id")
            .Produces<GetMiddleLinearProgressResponse>()
            .MapToApiVersion(1);
    }
}
