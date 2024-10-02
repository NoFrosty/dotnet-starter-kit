using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed class UpdateMiddleLinearProgressHandler(
    [FromKeyedServices("math:middleLinearProgress")] IRepository<MiddleLinearProgressItem> repository,
    ILogger<UpdateMiddleLinearProgressHandler> logger)
    : IRequestHandler<UpdateMiddleLinearProgressCommandPlayerId, UpdateMiddleLinearProgressResponse>
{
    public async Task<UpdateMiddleLinearProgressResponse> Handle(UpdateMiddleLinearProgressCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var middleLinearProgress = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<MiddleLinearProgressItem>(request.PlayerId), cancellationToken);

        if (middleLinearProgress == null)
        {
            // Create a new MiddleLinearProgressItem if not found
            middleLinearProgress = MiddleLinearProgressItem.Create(request.PlayerId, 0); // Assuming default Progress is 0
            await repository.AddAsync(middleLinearProgress, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        var updatedMiddleLinearProgress = middleLinearProgress.Update(request.Data.Progress);
        await repository.UpdateAsync(updatedMiddleLinearProgress, cancellationToken);
        logger.LogInformation("middleLinearProgress with id : {MiddleLinearProgressId} updated", middleLinearProgress.Id);

        return new UpdateMiddleLinearProgressResponse(middleLinearProgress.Id);
    }
}
