using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record ProgressItemUpdated(ProgressItem item) : DomainEvent;

public class ProgressItemUpdatedEventHandler(
    ILogger<ProgressItemUpdatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<ProgressItemUpdated>
{
    public async Task Handle(ProgressItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling progress item updated domain event..");
        var cacheResponse = new GetProgressResponse(notification.item.Unit1Progress, notification.item.Unit2Progress, notification.item.Unit3Progress, notification.item.Unit4Progress, notification.item.Unit5Progress, notification.item.Unit6Progress, notification.item.Unit7Progress);
        await cache.SetAsync($"progress:{notification.item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
