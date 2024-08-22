using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateHeartCommand(
    [property: DefaultValue("")] Guid? PlayerId,
    [property: DefaultValue(0)] int? AmountOfHeart
    ) : IRequest<CreateHeartResponse>;
