using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateProgressHandler(
    ILogger<CreateProgressHandler> logger,
    [FromKeyedServices("english:progress")] IRepository<ProgressItem> repository)
    : IRequestHandler<CreateProgressCommandPlayerId, CreateProgressResponse>
{
    public async Task<CreateProgressResponse> Handle(CreateProgressCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var progress = ProgressItem.Create(request.PlayerId, request.Data.Unit1Progress,
            request.Data.Unit2Progress,
            request.Data.Unit3Progress,
            request.Data.Unit4Progress,
            request.Data.Unit5Progress,
            request.Data.Unit6Progress,
            request.Data.Unit7Progress);
        await repository.AddAsync(progress, cancellationToken);
        logger.LogInformation("progress created {ProgressId}", progress.Id);
        return new CreateProgressResponse(progress.Id);
    }
}
