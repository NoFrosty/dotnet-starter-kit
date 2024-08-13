using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record HeartItemUpdated(HeartItem item) : DomainEvent;

public class HeartItemUpdatedEventHandler(
    ILogger<HeartItemUpdatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<HeartItemUpdated>
{
    public async Task Handle(HeartItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling heart item updated domain event..");
        var cacheResponse = new GetHeartResponse(notification.item.Id, notification.item.PlayerId, notification.item.AmountOfHeart);
        await cache.SetAsync($"heart:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
