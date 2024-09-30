using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record ProgressItemCreated(Guid Id, Guid PlayerId, int Unit1Progress, int Unit2Progress, int Unit3Progress, int Unit4Progress, int Unit5Progress, int Unit6Progress, int Unit7Progress) : DomainEvent;

public class ProgressItemCreatedEventHandler(
    ILogger<ProgressItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<ProgressItemCreated>
{
    public async Task Handle(ProgressItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling progress item created domain event..");
        var cacheResponse = new GetProgressResponse(notification.Unit1Progress, notification.Unit2Progress, notification.Unit3Progress, notification.Unit4Progress, notification.Unit5Progress, notification.Unit6Progress, notification.Unit7Progress);
        await cache.SetAsync($"progress:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
