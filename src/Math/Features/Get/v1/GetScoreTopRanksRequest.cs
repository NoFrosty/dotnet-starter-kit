using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public class GetScoreTopRanksRequest : IRequest<GetScoreTopRanksResponse>
{
    public GetScoreTopRanksRequest() { }
}
