using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetElemNumScoreHandler(
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository)
    : IRequestHandler<GetScoreRequest, GetScoreResponse>
{
    public async Task<GetScoreResponse> Handle(GetScoreRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScore = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<ElemNumScoreItem>(request.PlayerId), cancellationToken);

        if (elemNumScore == null)
        {
            // Create a new ElemNumScoreItem if not found
            elemNumScore = ElemNumScoreItem.Create(request.PlayerId, 0); // Assuming default score is 0
            await repository.AddAsync(elemNumScore, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<ElemNumScoreItem>(elemNumScore.Score), cancellationToken) + 1;
        return new GetScoreResponse(elemNumScore.Score, rank);
    }
}
