using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Domain.Events;
public record ElemNumScoreItemCreated(Guid Id, Guid PlayerId, int Score) : DomainEvent;

public class ElemNumScoreItemCreatedEventHandler(
    ILogger<ElemNumScoreItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<ElemNumScoreItemCreated>
{
    public async Task Handle(ElemNumScoreItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling elem num score item created domain event..");


        var cacheResponse = new GetScoreResponse(notification.Score, -1);
        await cache.SetAsync($"elemNumScore:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
