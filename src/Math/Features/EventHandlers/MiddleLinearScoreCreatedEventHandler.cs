using FSH.Starter.WebApi.Math.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.EventHandlers;
public class MiddleLinearScoreCreatedEventHandler
    (ILogger<MiddleLinearScoreCreatedEventHandler> logger) : INotificationHandler<MiddleLinearScoreCreated>
{
    public async Task Handle(MiddleLinearScoreCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling elem num score created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling elem num score created domain event..");
    }
}
