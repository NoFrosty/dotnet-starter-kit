using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record NpcItemCreated(Guid Id, string Name) : DomainEvent;

public class NpcItemCreatedEventHandler(
    ILogger<NpcItemCreatedEventHandler> logger,
    ICacheService cache)
: INotificationHandler<NpcItemCreated>
{
    public async Task Handle(NpcItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling npc item created domain event..");
        var cacheResponse = new GetNpcResponse(notification.Id, notification.Name);
        await cache.SetAsync($"npc:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
