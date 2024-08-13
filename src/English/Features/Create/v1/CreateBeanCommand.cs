using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateBeanCommand(
    [property: DefaultValue("")] Guid? PlayerId,
    [property: DefaultValue("")] Guid? NpcId,
    [property: DefaultValue(0)] int? AmountOfBean) : IRequest<CreateBeanResponse>;
