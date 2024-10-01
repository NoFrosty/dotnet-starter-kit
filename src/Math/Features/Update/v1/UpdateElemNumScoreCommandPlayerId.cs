using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed record UpdateElemNumScoreCommandPlayerId(Guid PlayerId, UpdateElemNumScoreCommand Data) : IRequest<UpdateElemNumScoreResponse>;
