using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Create.v1;
public sealed record CreateElemNumScoreCommandPlayerId(
    Guid PlayerId,
    CreateElemNumScoreCommand Data
    ) : IRequest<CreateElemNumScoreResponse>;
