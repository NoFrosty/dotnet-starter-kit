using FSH.Starter.WebApi.English.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.English.Endpoints.v1;
public static class UpdateBeanEndpoint
{
    internal static RouteHandlerBuilder MapBeanUpdationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateBeanCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateBeanEndpoint))
            .WithSummary("update a user bean amount")
            .WithDescription("update a user bean amount")
            .Produces<UpdateBeanResponse>()
            .MapToApiVersion(1);
    }
}
