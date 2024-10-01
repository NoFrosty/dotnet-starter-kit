using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record MiddleLinearScoreItemCreated(Guid Id, Guid PlayerId, int Score) : DomainEvent;

public class MiddleLinearScoreItemCreatedEventHandler(
    ILogger<MiddleLinearScoreItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<MiddleLinearScoreItemCreated>
{
    public async Task Handle(MiddleLinearScoreItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling middle linear score item created domain event..");


        var cacheResponse = new GetScoreResponse(notification.Score, -1);
        await cache.SetAsync($"middleLinearScore:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
