using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record BeanItemIncreased(BeanItem Item) : DomainEvent;

public class BeanItemIncreasedEventHandler(
       ILogger<BeanItemIncreasedEventHandler> logger,
          ICacheService cache)
    : INotificationHandler<BeanItemIncreased>
{
    public async Task Handle(BeanItemIncreased notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling bean item amount increased domain event..");
        var cacheResponse = new GetBeanResponse(notification.Item.Id, notification.Item.PlayerId, notification.Item.NpcId, notification.Item.AmountOfBean);
        await cache.SetAsync($"bean:{notification.Item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
