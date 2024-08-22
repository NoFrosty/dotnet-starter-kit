using MediatR;

namespace FSH.Starter.WebApi.English.Features.Delete.v1;
public sealed record DeleteHeartCommand(
    Guid PlayerId) : IRequest;
