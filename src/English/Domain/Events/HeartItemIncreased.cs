using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record HeartItemIncreased(HeartItem item) : DomainEvent;

public class HeartItemIncreasedEventHandler(
    ILogger<HeartItemIncreasedEventHandler> logger,
    ICacheService cache) : INotificationHandler<HeartItemIncreased>
{
    public async Task Handle(HeartItemIncreased notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling heart amount increased domain event..");
        var cacheResponse = new GetHeartResponse(notification.item.Id, notification.item.PlayerId, notification.item.AmountOfHeart);
        await cache.SetAsync($"heart:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
