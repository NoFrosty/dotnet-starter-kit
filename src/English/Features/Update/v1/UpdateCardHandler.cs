using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
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

        if (card == null)
        {
            card = CardItem.Create(request.PlayerId, request.Data.UnlockedCards);
            await repository.AddAsync(card, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var updatedCard = card.Update(request.Data.UnlockedCards);
            await repository.UpdateAsync(updatedCard, cancellationToken);
        }

        logger.LogInformation("card with id : {CardId} updated", card.Id);
        return new UpdateCardResponse(card.Id);
    }
}
