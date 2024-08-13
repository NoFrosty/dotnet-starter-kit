using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Domain;

namespace FSH.Starter.WebApi.English.Events;
public sealed record NpcCreated : DomainEvent
{
    public NpcItem? NpcItem { get; set; }
}
