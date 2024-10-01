using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record ElemNumScoreItemUpdated(ElemNumScoreItem item) : DomainEvent;

public class ElemNumScoreItemUpdatedEventHandler(
    ILogger<ElemNumScoreItemUpdatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<ElemNumScoreItemUpdated>
{
    public async Task Handle(ElemNumScoreItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling elem num score item updated domain event..");
        var cacheResponse = new GetScoreResponse(notification.item.Score, -2);
        await cache.SetAsync($"elemNumScore:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
