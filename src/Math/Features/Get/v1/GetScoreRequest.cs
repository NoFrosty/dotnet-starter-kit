using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public class GetScoreRequest : IRequest<GetScoreResponse>
{
    public Guid PlayerId { get; set; }
    public GetScoreRequest(Guid playerId) => PlayerId = playerId;
}
