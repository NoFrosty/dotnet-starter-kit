using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed record UpdateScoreCommandPlayerId(Guid PlayerId, UpdateScoreCommand Data) : IRequest<UpdateScoreResponse>;
