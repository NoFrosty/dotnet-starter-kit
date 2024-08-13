using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateNpcCommand(
       Guid Id,
          string Name) : IRequest<UpdateNpcResponse>;
