using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.English.Domain;

namespace FSH.Starter.WebApi.English.Events;
public sealed record ProgressCreated : DomainEvent
{
    public ProgressItem? ProgressItem { get; set; }
}
