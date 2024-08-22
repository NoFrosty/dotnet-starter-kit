using FSH.Starter.WebApi.English.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.EventHandlers;
public class HeartCreatedEventHandler(ILogger<HeartCreatedEventHandler> logger) : INotificationHandler<HeartCreated>
{
    public async Task Handle(HeartCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling heart created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling heart created domain event..");
    }
}
