using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateHeartCommandPlayerId(
    Guid PlayerId,
    CreateHeartCommand Data
    ) : IRequest<CreateHeartResponse>;
