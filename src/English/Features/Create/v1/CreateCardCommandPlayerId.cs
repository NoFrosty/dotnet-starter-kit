using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateCardCommandPlayerId(
    Guid PlayerId,
    CreateCardCommand Data
    ) : IRequest<CreateCardResponse>;
