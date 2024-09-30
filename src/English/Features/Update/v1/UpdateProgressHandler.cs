using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed class UpdateProgressHandler(
    [FromKeyedServices("english:progress")] IRepository<ProgressItem> repository,
    ILogger<UpdateProgressHandler> logger)
    : IRequestHandler<UpdateProgressCommandPlayerId, UpdateProgressResponse>
{
    public async Task<UpdateProgressResponse> Handle(UpdateProgressCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var progress = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<ProgressItem>(request.PlayerId), cancellationToken);
        _ = progress ?? throw new ProgressNotFoundException(request.PlayerId);
        var updatedProgress = progress.Update(
            request.Data.Unit1Progress,
            request.Data.Unit2Progress,
            request.Data.Unit3Progress,
            request.Data.Unit4Progress,
            request.Data.Unit5Progress,
            request.Data.Unit6Progress,
            request.Data.Unit7Progress
            );

        await repository.UpdateAsync(updatedProgress, cancellationToken);
        logger.LogInformation("progress with id : {ProgressId} updated", progress.Id);
        return new UpdateProgressResponse(progress.Id);
    }
}
