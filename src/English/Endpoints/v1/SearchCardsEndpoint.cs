using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.English.Features.Get.v1;
using FSH.Starter.WebApi.English.Features.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class SearchCardsEndpoint
{
    internal static RouteHandlerBuilder MapGetCardListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/search", async (ISender mediator, [FromBody] PaginationFilter filter) =>
        {
            var response = await mediator.Send(new SearchCardsCommand(filter));
            return Results.Ok(response);
        })
            .WithName(nameof(SearchCardsEndpoint))
            .WithSummary("searches for cards collection")
            .WithDescription("searches for cards collection")
            .Produces<PagedList<GetCardResponse>>()
            .MapToApiVersion(1)
            .RequirePermission("Permissions.Cards.Search");
    }
}
