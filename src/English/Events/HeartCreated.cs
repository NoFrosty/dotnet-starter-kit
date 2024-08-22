using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Domain;

namespace FSH.Starter.WebApi.English.Events;
public sealed record HeartCreated : DomainEvent
{
    public HeartItem? HeartItem { get; set; }
}
