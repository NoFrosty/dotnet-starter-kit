using FSH.Framework.Core.Identity.Users.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public sealed class GetMiddleLinearScoreTopRanksHandler(
    [FromKeyedServices("math:middleLinearScores")] IRepository<MiddleLinearScoreItem> repository,
    IUserService userService)
    : IRequestHandler<GetScoreTopRanksRequest, GetScoreTopRanksResponse>
{
    public async Task<GetScoreTopRanksResponse> Handle(GetScoreTopRanksRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var middleLinearScores = await repository.ListAsync(new Top10EntitiesOrderedByScoreSpec<MiddleLinearScoreItem>(), cancellationToken);

        List<RankItem> ranking = new();

        foreach (var middleLinearScore in middleLinearScores)
        {
            var user = await userService.GetAsync(middleLinearScore.PlayerId.ToString(), cancellationToken);
            if (user?.UserName != null)
            {
                ranking.Add(new RankItem(user.UserName, middleLinearScore.Score));
            }
        }

        return new GetScoreTopRanksResponse(ranking);
    }
}
