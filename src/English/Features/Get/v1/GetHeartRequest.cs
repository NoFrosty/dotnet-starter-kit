using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetHeartRequest : IRequest<GetHeartResponse>
{
    public Guid PlayerId { get; set; }
    public GetHeartRequest(Guid playerId) => PlayerId = playerId;
}
