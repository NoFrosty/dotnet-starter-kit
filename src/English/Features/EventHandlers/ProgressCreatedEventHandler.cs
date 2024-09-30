using FSH.Starter.WebApi.English.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.EventHandlers;
public class ProgressCreatedEventHandler(ILogger<ProgressCreatedEventHandler> logger) :
    INotificationHandler<ProgressCreated>
{
    public async Task Handle(ProgressCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling progress created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling progress created domain event..");
    }
}
