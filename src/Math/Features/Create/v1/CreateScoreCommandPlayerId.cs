using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Create.v1;
public sealed record CreateScoreCommandPlayerId(
    Guid PlayerId,
    CreateScoreCommand Data
    ) : IRequest<CreateScoreResponse>;
