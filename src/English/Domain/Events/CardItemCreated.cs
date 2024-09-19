using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record CardItemCreated(Guid Id, Guid PlayerId, Dictionary<string, List<bool>> UnlockedCards) : DomainEvent;


public class CardItemCreatedEventHandler(
    ILogger<CardItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<CardItemCreated>
{
    public async Task Handle(CardItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling card item created domain event..");
        var cacheResponse = new GetCardResponse(notification.UnlockedCards);
        await cache.SetAsync($"card:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
