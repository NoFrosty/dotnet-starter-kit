using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateHeartHandler(
    ILogger<CreateHeartHandler> logger,
    [FromKeyedServices("english:hearts")] IRepository<HeartItem> repository)
    : IRequestHandler<CreateHeartCommand, CreateHeartResponse>
{
    public async Task<CreateHeartResponse> Handle(CreateHeartCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var heart = HeartItem.Create((Guid)request.PlayerId!, (int)request.AmountOfHeart!);
        await repository.AddAsync(heart, cancellationToken);
        logger.LogInformation("heart created {HeartId}", heart.Id);
        return new CreateHeartResponse(heart.Id);
    }
}
