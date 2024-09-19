using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateCardCommandPlayerId(Guid PlayerId, UpdateCardCommand Data) : IRequest<UpdateCardResponse>;
