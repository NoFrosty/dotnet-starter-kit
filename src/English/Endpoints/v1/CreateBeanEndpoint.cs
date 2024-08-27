using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class CreateBeanEndpoint
{
    internal static RouteHandlerBuilder MapBeanCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (ClaimsPrincipal user, CreateBeanCommand request, ISender mediator) =>
        {
            if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException();
            }

            CreateBeanCommandPlayerId requestId = new CreateBeanCommandPlayerId(new Guid(userId), request);
            var response = await mediator.Send(requestId);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateBeanEndpoint))
            .WithSummary("creates a bean counter for a user")
            .WithDescription("creates a bean counter for a user")
            .Produces<CreateBeanResponse>()
            .MapToApiVersion(1);
    }
}
