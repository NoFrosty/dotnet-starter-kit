using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetProgressRequest : IRequest<GetProgressResponse>
{
    public Guid PlayerId { get; set; }
    public GetProgressRequest(Guid playerId) => PlayerId = playerId;
}
