using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record MiddleLinearScoreItemUpdated(MiddleLinearScoreItem item) : DomainEvent;

public class MiddleLinearScoreItemUpdatedEventHandler(
    ILogger<MiddleLinearScoreItemUpdatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<MiddleLinearScoreItemUpdated>
{
    public async Task Handle(MiddleLinearScoreItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling middle linear score item updated domain event..");
        var cacheResponse = new GetScoreResponse(notification.item.Score, -2);
        await cache.SetAsync($"middleLinearScore:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
