using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Delete.v1;
public sealed class DeleteHeartHandler(
    ILogger<DeleteHeartHandler> logger,
    [FromKeyedServices("english:hearts")] IRepository<HeartItem> repository)
    : IRequestHandler<DeleteHeartCommand>
{
    public async Task Handle(DeleteHeartCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var heart = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<HeartItem>(request.PlayerId), cancellationToken);
        _ = heart ?? throw new HeartNotFoundException(request.PlayerId);
        await repository.DeleteAsync(heart, cancellationToken);
        logger.LogInformation("heart with id : {HeartId} deleted", heart.Id);
    }
}
