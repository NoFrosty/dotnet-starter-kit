using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetMiddleLinearScoreHandler(
    [FromKeyedServices("math:middleLinearScores")] IRepository<MiddleLinearScoreItem> repository)
    : IRequestHandler<GetScoreRequest, GetScoreResponse>
{
    public async Task<GetScoreResponse> Handle(GetScoreRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var middleLinearScore = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<MiddleLinearScoreItem>(request.PlayerId), cancellationToken);

        if (middleLinearScore == null)
        {
            // Create a new MiddleLinearScoreItem if not found
            middleLinearScore = MiddleLinearScoreItem.Create(request.PlayerId, 0); // Assuming default score is 0
            await repository.AddAsync(middleLinearScore, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<MiddleLinearScoreItem>(middleLinearScore.Score), cancellationToken) + 1;
        return new GetScoreResponse(middleLinearScore.Score, rank);
    }
}
