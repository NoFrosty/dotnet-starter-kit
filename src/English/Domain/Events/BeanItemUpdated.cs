using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record BeanItemUpdated(BeanItem Item) : DomainEvent;

public class BeanItemUpdatedEventHandler(

    ILogger<BeanItemUpdatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<BeanItemUpdated>
{
    public async Task Handle(BeanItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling bean item updated domain event..");
        var cacheResponse = new GetBeanResponse(notification.Item.Id, notification.Item.PlayerId, notification.Item.AmountOfBeanMuzzy, notification.Item.AmountOfBeanBurn, notification.Item.AmountOfBeanCube, notification.Item.AmountOfBeanRoxy, notification.Item.AmountOfBeanOllie, notification.Item.AmountOfBeanNova, notification.Item.AmountOfBeanBeebee, notification.Item.AmountOfBeanLuna, notification.Item.AmountOfBeanFurry);
        await cache.SetAsync($"bean:{notification.Item.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
