using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Create.v1;
public sealed class CreateElemNumScoreHandler(
    ILogger<CreateElemNumScoreHandler> logger,
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository
    ) : IRequestHandler<CreateElemNumScoreCommandPlayerId, CreateElemNumScoreResponse>
{
    public async Task<CreateElemNumScoreResponse> Handle(CreateElemNumScoreCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScore = ElemNumScoreItem.Create(request.PlayerId, request.Data.Score);
        await repository.AddAsync(elemNumScore, cancellationToken);
        logger.LogInformation("elemNumScore created {ElemNumScoreId}", elemNumScore.Id);
        return new CreateElemNumScoreResponse(elemNumScore.Id, elemNumScore.Score);
    }
}
