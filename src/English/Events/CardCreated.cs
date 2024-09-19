using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Domain;

namespace FSH.Starter.WebApi.English.Events;
public sealed record CardCreated : DomainEvent
{
    public CardItem? CardItem { get; set; }
}
