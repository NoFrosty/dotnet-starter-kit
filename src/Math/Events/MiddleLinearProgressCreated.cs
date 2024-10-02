using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Math.Domain;

namespace FSH.Starter.WebApi.Math.Events;
public sealed record MiddleLinearProgressCreated : DomainEvent
{
    public MiddleLinearProgressItem? MiddleLinearProgressItem { get; set; }
}
