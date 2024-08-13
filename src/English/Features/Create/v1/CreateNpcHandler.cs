using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateNpcHandler(
    ILogger<CreateNpcHandler> logger,
    [FromKeyedServices("english:npcs")] IRepository<NpcItem> repository)
    : IRequestHandler<CreateNpcCommand, CreateNpcResponse>
{
    public async Task<CreateNpcResponse> Handle(CreateNpcCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var npc = NpcItem.Create(request.Name!);
        await repository.AddAsync(npc, cancellationToken);
        logger.LogInformation("npc created {NpcId}", npc.Id);
        return new CreateNpcResponse(npc.Id);
    }
}
