using MediatR;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public class GetBeanRequest : IRequest<GetBeanResponse>
{
    public Guid Id { get; set; }
    public GetBeanRequest(Guid id) => Id = id;
}
