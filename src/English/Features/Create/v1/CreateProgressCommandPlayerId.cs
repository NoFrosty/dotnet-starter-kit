using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateProgressCommandPlayerId(
    Guid PlayerId,
    CreateProgressCommand Data
    ) : IRequest<CreateProgressResponse>;
