using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed class UpdateHeartHandler(
    [FromKeyedServices("english:hearts")] IRepository<HeartItem> repository,
    ILogger<UpdateHeartHandler> logger)
    : IRequestHandler<UpdateHeartCommandPlayerId, UpdateHeartResponse>
{
    public async Task<UpdateHeartResponse> Handle(UpdateHeartCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var heart = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<HeartItem>(request.PlayerId), cancellationToken);
        _ = heart ?? throw new HeartNotFoundException(request.PlayerId);
        var updatedHeart = heart.Update(request.Data.AmountOfHeart);

        await repository.UpdateAsync(updatedHeart, cancellationToken);
        logger.LogInformation("heart with id : {HeartId} updated", heart.Id);
        return new UpdateHeartResponse(heart.PlayerId);
    }
}
