using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.English.Features.Get.v1;
using FSH.Starter.WebApi.English.Features.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class SearchHeartsEndpoint
{
    internal static RouteHandlerBuilder MapGetHeartListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/search", async (ISender mediator, [FromBody] PaginationFilter filter) =>
        {
            var response = await mediator.Send(new SearchHeartsCommand(filter));
            return Results.Ok(response);
        })
            .WithName(nameof(SearchHeartsEndpoint))
            .WithSummary("searches for heart counters")
            .WithDescription("searches for heart counters")
            .Produces<PagedList<GetHeartResponse>>()
            .MapToApiVersion(1);
    }
}
