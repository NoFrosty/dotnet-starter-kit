using FSH.Framework.Core.Identity.Users.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetElemNumScoreTopRanksHandler(
    [FromKeyedServices("math:elemNumScores")] IRepository<ElemNumScoreItem> repository,
    IUserService userService)
    : IRequestHandler<GetElemNumScoreTopRanksRequest, GetElemNumScoreTopRanksResponse>
{
    public async Task<GetElemNumScoreTopRanksResponse> Handle(GetElemNumScoreTopRanksRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var elemNumScores = await repository.ListAsync(new Top10EntitiesOrderedByScoreSpec<ElemNumScoreItem>(), cancellationToken);

        List<RankItem> ranking = new();

        foreach (var elemNumScore in elemNumScores)
        {
            var user = await userService.GetAsync(elemNumScore.PlayerId.ToString(), cancellationToken);
            if (user?.UserName != null)
            {
                ranking.Add(new RankItem(user.UserName, elemNumScore.Score));
            }
        }

        return new GetElemNumScoreTopRanksResponse(ranking);
    }
}
