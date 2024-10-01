using FSH.Starter.WebApi.Math.Domain;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public record GetScoreTopRanksResponse(List<RankItem> Ranking);
