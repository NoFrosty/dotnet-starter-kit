using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using FSH.Starter.WebApi.Math.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed class UpdateElemNumScoreHandler(
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository,
    ILogger<UpdateElemNumScoreHandler> logger)
    : IRequestHandler<UpdateElemNumScoreCommandPlayerId, UpdateElemNumScoreResponse>
{
    public async Task<UpdateElemNumScoreResponse> Handle(UpdateElemNumScoreCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScore = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<ElemNumScoreItem>(request.PlayerId), cancellationToken);
        _ = elemNumScore ?? throw new ElemNumScoreNotFoundException(request.PlayerId);
        var updatedElemNumScore = elemNumScore.Update(request.Data.Score);
        await repository.UpdateAsync(updatedElemNumScore, cancellationToken);
        logger.LogInformation("elemNumScore with id : {ElemNumScoreId} updated", elemNumScore.Id);

        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<ElemNumScoreItem>(elemNumScore.Score), cancellationToken) + 1;

        return new UpdateElemNumScoreResponse(elemNumScore.Id, rank);
    }
}
