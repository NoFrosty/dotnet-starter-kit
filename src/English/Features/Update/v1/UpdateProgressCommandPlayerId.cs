using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateProgressCommandPlayerId(Guid PlayerId, UpdateProgressCommand Data) : IRequest<UpdateProgressResponse>;
