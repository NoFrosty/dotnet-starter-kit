using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Update.v1;
public sealed class UpdateMiddleLinearScoreHandler(
    [FromKeyedServices("math:middleLinearScores")] IRepository<MiddleLinearScoreItem> repository,
    ILogger<UpdateMiddleLinearScoreHandler> logger)
    : IRequestHandler<UpdateScoreCommandPlayerId, UpdateScoreResponse>
{
    public async Task<UpdateScoreResponse> Handle(UpdateScoreCommandPlayerId request, CancellationToken cancellationToken)
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

        var updatedMiddleLinearScore = middleLinearScore.Update(request.Data.Score);
        await repository.UpdateAsync(updatedMiddleLinearScore, cancellationToken);
        logger.LogInformation("middleLinearScore with id : {MiddleLinearScoreId} updated", middleLinearScore.Id);

        int rank = await repository.CountAsync(new EntitiesWithScoreGreaterThanSpec<MiddleLinearScoreItem>(middleLinearScore.Score), cancellationToken) + 1;

        return new UpdateScoreResponse(middleLinearScore.Id, rank);
    }
}
