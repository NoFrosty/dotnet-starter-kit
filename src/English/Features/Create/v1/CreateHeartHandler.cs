using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateHeartHandler(
    ILogger<CreateHeartHandler> logger,
    [FromKeyedServices("english:hearts")] IRepository<HeartItem> repository)
    : IRequestHandler<CreateHeartCommandPlayerId, CreateHeartResponse>
{
    public async Task<CreateHeartResponse> Handle(CreateHeartCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var heart = HeartItem.Create(request.PlayerId, request.Data.AmountOfHeart);
        await repository.AddAsync(heart, cancellationToken);
        logger.LogInformation("heart created {HeartId}", heart.Id);
        return new CreateHeartResponse(heart.Id);
    }
}
