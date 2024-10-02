using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record MiddleLinearProgressItemUpdated(MiddleLinearProgressItem item) : DomainEvent;

public class MiddleLinearProgressItemUpdatedEventHandler(
    ILogger<MiddleLinearProgressItemUpdatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<MiddleLinearProgressItemUpdated>
{
    public async Task Handle(MiddleLinearProgressItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling middle linear progress item updated domain event..");
        var cacheResponse = new GetMiddleLinearProgressResponse(notification.item.Progress);
        await cache.SetAsync($"middleLinearProgress:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
