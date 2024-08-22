using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetBeanRequest : IRequest<GetBeanResponse>
{
    public Guid PlayerId { get; set; }
    public GetBeanRequest(Guid playerId) => PlayerId = playerId;
}
