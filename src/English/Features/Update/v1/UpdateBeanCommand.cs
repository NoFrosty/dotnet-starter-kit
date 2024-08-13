using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateBeanCommand(
       Guid Id,
          int AmountOfBean) : IRequest<UpdateBeanResponse>;
