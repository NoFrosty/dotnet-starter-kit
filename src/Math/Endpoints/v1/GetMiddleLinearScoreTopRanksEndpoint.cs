using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Math.Endpoints.v1;
public static class GetMiddleLinearScoreTopRanksEndpoint
{
    internal static RouteHandlerBuilder MapGetMiddleLinearScoreTopRanksEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/topranks", async (ISender mediator) =>
            {
                var response = await mediator.Send(new GetScoreTopRanksRequest());
                return Results.Ok(response);
            })
            .WithName(nameof(GetMiddleLinearScoreTopRanksEndpoint))
            .WithSummary("gets top ranks for element number score")
            .WithDescription("gets top ranks for element number score")
            .Produces<GetScoreTopRanksResponse>()
            .MapToApiVersion(1);
    }
}
