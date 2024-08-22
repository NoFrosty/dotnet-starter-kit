﻿using FSH.Starter.WebApi.English.Features.Update.v1;
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
            .MapPut("/", async (UpdateBeanCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateBeanEndpoint))
            .WithSummary("update bean counter for a user")
            .WithDescription("update bean counter for a user")
            .Produces<UpdateBeanResponse>()
            .MapToApiVersion(1);
    }
}
