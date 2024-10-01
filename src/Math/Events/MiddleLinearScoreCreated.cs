using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Domain;

namespace FSH.Starter.WebApi.Math.Events;
public sealed record MiddleLinearScoreCreated : DomainEvent
{
    public MiddleLinearScoreItem? MiddleLinearScoreItem { get; set; }
}
