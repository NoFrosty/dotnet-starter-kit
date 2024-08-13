using FSH.Starter.WebApi.English.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.EventHandlers;
public class BeanCreatedEventHandler(ILogger<BeanCreatedEventHandler> logger) : INotificationHandler<BeanCreated>
{
    public async Task Handle(BeanCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling bean created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling bean created domain event..");
    }
}
