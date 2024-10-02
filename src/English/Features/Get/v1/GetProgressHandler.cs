using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public sealed class GetProgressHandler(
     [FromKeyedServices("english:progress")] IRepository<ProgressItem> repository)
    : IRequestHandler<GetProgressRequest, GetProgressResponse>
{
    public async Task<GetProgressResponse> Handle(GetProgressRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var progressItem = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<ProgressItem>(request.PlayerId), cancellationToken);

        if (progressItem == null)
        {
            progressItem = ProgressItem.Create(request.PlayerId, 0, 0, 0, 0, 0, 0, 0);
            await repository.AddAsync(progressItem, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        return new GetProgressResponse(progressItem.Unit1Progress, progressItem.Unit2Progress, progressItem.Unit3Progress, progressItem.Unit4Progress, progressItem.Unit5Progress, progressItem.Unit6Progress, progressItem.Unit7Progress);
    }
}
