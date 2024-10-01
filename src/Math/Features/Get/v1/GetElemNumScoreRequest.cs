using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public class GetElemNumScoreRequest : IRequest<GetElemNumScoreResponse>
{
    public Guid PlayerId { get; set; }
    public GetElemNumScoreRequest(Guid playerId) => PlayerId = playerId;
}
