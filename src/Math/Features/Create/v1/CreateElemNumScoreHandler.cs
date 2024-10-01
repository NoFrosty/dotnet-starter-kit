using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Math.Features.Create.v1;
public sealed class CreateElemNumScoreHandler(
    ILogger<CreateElemNumScoreHandler> logger,
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository
    ) : IRequestHandler<CreateScoreCommandPlayerId, CreateScoreResponse>
{
    public async Task<CreateScoreResponse> Handle(CreateScoreCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScore = ElemNumScoreItem.Create(request.PlayerId, request.Data.Score);
        await repository.AddAsync(elemNumScore, cancellationToken);
        logger.LogInformation("elemNumScore created {ElemNumScoreId}", elemNumScore.Id);
        return new CreateScoreResponse(elemNumScore.Id, elemNumScore.Score);
    }
}
