using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateBeanCommandPlayerId(Guid PlayerId, UpdateBeanCommand Data) : IRequest<UpdateBeanResponse>;
