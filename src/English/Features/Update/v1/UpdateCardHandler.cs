using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed class UpdateCardHandler(
    [FromKeyedServices("english:cards")] IRepository<CardItem> repository,
    ILogger<UpdateCardHandler> logger)
    : IRequestHandler<UpdateCardCommandPlayerId, UpdateCardResponse>
{
    public async Task<UpdateCardResponse> Handle(UpdateCardCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var card = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<CardItem>(request.PlayerId), cancellationToken);
        _ = card ?? throw new CardNotFoundException(request.PlayerId);
        var updatedCard = card.Update(request.Data.UnlockedCards);

        await repository.UpdateAsync(updatedCard, cancellationToken);
        logger.LogInformation("card with id : {CardId} updated", card.Id);
        return new UpdateCardResponse(card.Id);
    }
}
