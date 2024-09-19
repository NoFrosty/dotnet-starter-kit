using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateCardHandler(
    ILogger<CreateCardHandler> logger,
    [FromKeyedServices("english:cards")] IRepository<CardItem> repository)
    : IRequestHandler<CreateCardCommandPlayerId, CreateCardResponse>
{
    public async Task<CreateCardResponse> Handle(CreateCardCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var card = CardItem.Create(request.PlayerId, request.Data.UnlockedCards);
        await repository.AddAsync(card, cancellationToken);
        logger.LogInformation("card created {CardId}", card.Id);
        return new CreateCardResponse(card.Id);
    }
}
