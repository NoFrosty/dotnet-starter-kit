using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed class UpdateElemNumScoreHandler(
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository,
    ILogger<UpdateElemNumScoreHandler> logger)
    : IRequestHandler<UpdateScoreCommandPlayerId, UpdateScoreResponse>
{
    public async Task<UpdateScoreResponse> Handle(UpdateScoreCommandPlayerId request, CancellationToken cancellationToken)
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

        var updatedElemNumScore = elemNumScore.Update(request.Data.Score);
        await repository.UpdateAsync(updatedElemNumScore, cancellationToken);
        logger.LogInformation("elemNumScore with id : {ElemNumScoreId} updated", elemNumScore.Id);

        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<ElemNumScoreItem>(elemNumScore.Score), cancellationToken) + 1;

        return new UpdateScoreResponse(elemNumScore.Id, rank);
    }
}
