using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Create.v1;
public sealed class CreateMiddleLinearScoreHandler(
    ILogger<CreateMiddleLinearScoreHandler> logger,
    [FromKeyedServices("math:middleLinearScores")] IRepository<MiddleLinearScoreItem> repository
    ) : IRequestHandler<CreateScoreCommandPlayerId, CreateScoreResponse>
{
    public async Task<CreateScoreResponse> Handle(CreateScoreCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var middleLinearScore = MiddleLinearScoreItem.Create(request.PlayerId, request.Data.Score);
        await repository.AddAsync(middleLinearScore, cancellationToken);
        logger.LogInformation("middleLinearScore created {MiddleLinearScoreId}", middleLinearScore.Id);
        return new CreateScoreResponse(middleLinearScore.Id, middleLinearScore.Score);
    }
}
