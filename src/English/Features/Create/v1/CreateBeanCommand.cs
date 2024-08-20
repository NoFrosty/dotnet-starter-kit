using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateBeanCommand(
    [property: DefaultValue("")] Guid? PlayerId,
    [property: DefaultValue(0)] int? AmountOfBeanMuzzy,
    [property: DefaultValue(0)] int? AmountOfBeanBurn,
    [property: DefaultValue(0)] int? AmountOfBeanCube,
    [property: DefaultValue(0)] int? AmountOfBeanRoxy,
    [property: DefaultValue(0)] int? AmountOfBeanOllie,
    [property: DefaultValue(0)] int? AmountOfBeanNova,
    [property: DefaultValue(0)] int? AmountOfBeanBeebee,
    [property: DefaultValue(0)] int? AmountOfBeanLuna,
    [property: DefaultValue(0)] int? AmountOfBeanFurry
    ) : IRequest<CreateBeanResponse>;
