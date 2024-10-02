using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record MiddleLinearProgressItemCreated(Guid Id, Guid PlayerId, int Progress) : DomainEvent;

public class MiddleLinearProgressItemCreatedEventHandler(
    ILogger<MiddleLinearProgressItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<MiddleLinearProgressItemCreated>
{
    public async Task Handle(MiddleLinearProgressItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling middle linear progress item created domain event..");


        var cacheResponse = new GetMiddleLinearProgressResponse(notification.Progress);
        await cache.SetAsync($"middleLinearProgress:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
