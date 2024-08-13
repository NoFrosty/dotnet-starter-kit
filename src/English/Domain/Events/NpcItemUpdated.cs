using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Domain.Events;
public record NpcItemUpdated(NpcItem npcItem) : DomainEvent;

public class NpcItemUpdatedEventHandler(
    ILogger<NpcItemUpdatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<NpcItemUpdated>
{
    public async Task Handle(NpcItemUpdated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling npc item updated domain event..");
        var cacheResponse = new GetNpcResponse(notification.npcItem.Id, notification.npcItem.Name);
        await cache.SetAsync($"npc:{notification.npcItem.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
