using MediatR;

namespace FSH.Starter.WebApi.English.Features.Delete.v1;
public sealed record DeleteNpcCommand(
       Guid Id) : IRequest;
