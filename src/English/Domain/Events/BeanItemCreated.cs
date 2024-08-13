using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record BeanItemCreated(Guid Id, Guid PlayerId, Guid NpcId, int AmountOfBean) : DomainEvent;

public class BeanItemCreatedEventHandler(
    ILogger<BeanItemCreatedEventHandler> logger,
    ICacheService cache) : INotificationHandler<BeanItemCreated>

{
    public async Task Handle(BeanItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling bean item created domain event..");
        var cacheResponse = new GetBeanResponse(notification.Id, notification.PlayerId, notification.NpcId, notification.AmountOfBean);
        await cache.SetAsync($"bean:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
