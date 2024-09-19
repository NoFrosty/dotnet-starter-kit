using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record CardItemUpdated(CardItem Item) : DomainEvent;

public class CardItemUpdatedEventHandler(
    ILogger<CardItemUpdatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<CardItemUpdated>
{
    public async Task Handle(CardItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling card item updated domain event..");
        var cacheResponse = new GetCardResponse(notification.Item.UnlockedCards);
        await cache.SetAsync($"card:{notification.Item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
