using FSH.Starter.WebApi.English.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.EventHandlers;
public class NpcCreatedEventHandler(ILogger<NpcCreatedEventHandler> logger) : INotificationHandler<NpcCreated>
{
    public async Task Handle(NpcCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling npc created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling npc created domain event..");
    }
}
