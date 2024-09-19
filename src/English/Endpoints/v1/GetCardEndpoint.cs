using System.Security.Claims;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class GetCardEndpoint
{
    internal static RouteHandlerBuilder MapGetCardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
           .MapGet("/", async (ClaimsPrincipal user, ISender mediator) =>
           {
               if (user.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
               {
                   throw new UnauthorizedAccessException();
               }
               var response = await mediator.Send(new GetCardRequest(new Guid(userId)));
               return Results.Ok(response);
           })
           .WithName(nameof(GetCardEndpoint))
           .WithSummary("gets card collection by user id")
           .WithDescription("gets card collection by user id")
           .Produces<GetCardResponse>()
           .MapToApiVersion(1);
    }
}
