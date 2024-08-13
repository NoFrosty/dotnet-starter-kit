using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class GetBeanEndpoint
{
    internal static RouteHandlerBuilder MapGetBeanEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetBeanRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetBeanEndpoint))
            .WithSummary("gets bean by id")
            .WithDescription("gets bean by id")
            .Produces<GetBeanResponse>()
            .MapToApiVersion(1);
    }
}
