using MediatR;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateHeartCommand(
       Guid PlayerId,
          int AmountOfHeart
          ) : IRequest<UpdateHeartResponse>;
