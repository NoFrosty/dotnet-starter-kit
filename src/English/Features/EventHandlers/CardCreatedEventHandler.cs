using FSH.Starter.WebApi.English.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.EventHandlers;
public class CardCreatedEventHandler(ILogger<CardCreatedEventHandler> logger) : INotificationHandler<CardCreated>
{
    public async Task Handle(CardCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling card created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling card created domain event..");
    }
}
