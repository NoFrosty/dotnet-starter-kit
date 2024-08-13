using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record HeartItemCreated(Guid Id, Guid PlayerId, int AmountOfHeart) : DomainEvent;

public class HeartItemCreatedEventHandler(
    ILogger<HeartItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<HeartItemCreated>
{
    public async Task Handle(HeartItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling heart item created domain event..");
        var cacheResponse = new GetHeartResponse(notification.Id, notification.PlayerId, notification.AmountOfHeart);
        await cache.SetAsync($"heart:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
