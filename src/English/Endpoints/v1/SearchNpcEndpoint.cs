using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.English.Features.Get.v1;
using FSH.Starter.WebApi.English.Features.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class SearchNpcEndpoint
{
    internal static RouteHandlerBuilder MapGetNpcListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] PaginationFilter filter) =>
            {
                var response = await mediator.Send(new SearchNpcsCommand(filter));
                return Results.Ok(response);
            })
            .WithName(nameof(SearchNpcEndpoint))
            .WithSummary("Gets a list of npcs")
            .WithDescription("Gets a list of npcs with pagination and filtering support")
            .Produces<PagedList<GetNpcResponse>>()
            .MapToApiVersion(1);
    }
}
