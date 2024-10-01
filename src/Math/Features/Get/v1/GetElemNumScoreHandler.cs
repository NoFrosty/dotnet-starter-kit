using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using FSH.Starter.WebApi.Math.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetElemNumScoreHandler(
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository)
    : IRequestHandler<GetElemNumScoreRequest, GetElemNumScoreResponse>
{
    public async Task<GetElemNumScoreResponse> Handle(GetElemNumScoreRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScore = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<ElemNumScoreItem>(request.PlayerId), cancellationToken);
        if (elemNumScore == null) throw new ElemNumScoreNotFoundException(request.PlayerId);
        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<ElemNumScoreItem>(elemNumScore.Score), cancellationToken) + 1;
        return new GetElemNumScoreResponse(elemNumScore.Score, rank);
    }
}
