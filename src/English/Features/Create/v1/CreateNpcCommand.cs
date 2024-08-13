using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateNpcCommand(
    [property: DefaultValue("Sample Npc")] string? Name
) : IRequest<CreateNpcResponse>;
