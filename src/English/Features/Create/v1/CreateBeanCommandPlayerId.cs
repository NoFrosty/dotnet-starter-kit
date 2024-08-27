using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateBeanCommandPlayerId(Guid PlayerId, CreateBeanCommand Data) : IRequest<CreateBeanResponse>;

