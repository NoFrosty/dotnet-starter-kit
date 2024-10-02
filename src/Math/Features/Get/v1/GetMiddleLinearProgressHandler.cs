using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetMiddleLinearProgressHandler(
    [FromKeyedServices("math:middleLinearProgress")] IRepository<MiddleLinearProgressItem> repository)
    : IRequestHandler<GetMiddleLinearProgressRequest, GetMiddleLinearProgressResponse>
{
    public async Task<GetMiddleLinearProgressResponse> Handle(GetMiddleLinearProgressRequest request, CancellationToken cancellationToken)
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

        return new GetMiddleLinearProgressResponse(middleLinearProgress.Progress);
    }
}
