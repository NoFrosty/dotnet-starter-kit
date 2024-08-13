using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetNpcRequest : IRequest<GetNpcResponse>
{
    public Guid Id { get; set; }
    public GetNpcRequest(Guid id) => Id = id;
}
