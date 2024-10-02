using MediatR;

namespace FSH.Starter.WebApi.Math.Features.Get.v1;
public class GetMiddleLinearProgressRequest : IRequest<GetMiddleLinearProgressResponse>
{
    public Guid PlayerId { get; set; }
    public GetMiddleLinearProgressRequest(Guid playerId) => PlayerId = playerId;
}
