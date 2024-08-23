using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateHeartCommandPlayerId(Guid PlayerId, UpdateHeartCommand Data) : IRequest<UpdateHeartResponse>;
