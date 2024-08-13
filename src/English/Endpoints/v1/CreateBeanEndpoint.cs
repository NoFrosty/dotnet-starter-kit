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
        return endpoints.MapPost("/", async (CreateBeanCommand request, ISender mediator) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
            .WithName(nameof(CreateBeanEndpoint))
            .WithSummary("creates a bean")
            .WithDescription("creates a bean")
            .Produces<CreateBeanResponse>()
            .MapToApiVersion(1);
    }
}
