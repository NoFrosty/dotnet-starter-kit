using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetCardRequest : IRequest<GetCardResponse>
{
    public Guid PlayerId { get; set; }
    public GetCardRequest(Guid playerId) => PlayerId = playerId;
}
