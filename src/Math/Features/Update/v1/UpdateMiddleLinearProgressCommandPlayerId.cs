using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed record UpdateMiddleLinearProgressCommandPlayerId(Guid PlayerId, UpdateMiddleLinearProgressCommand Data) : IRequest<UpdateMiddleLinearProgressResponse>;
