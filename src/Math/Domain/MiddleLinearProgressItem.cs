using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain.Events;

namespace FSH.Starter.WebApi.Math.Domain;
public class MiddleLinearProgressItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities
{
    public Guid PlayerId { get; set; }
    public int Progress { get; set; }

    public static MiddleLinearProgressItem Create(Guid playerId, int progress)
    {
        var item = new MiddleLinearProgressItem();

        item.PlayerId = playerId;
        item.Progress = progress;

        item.QueueDomainEvent(new MiddleLinearProgressItemCreated(item.Id, item.PlayerId, item.Progress));

        return item;
    }

    public MiddleLinearProgressItem Update(int progress)
    {
        if (Progress != progress) Progress = progress;

        this.QueueDomainEvent(new MiddleLinearProgressItemUpdated(this));

        return this;

    }
}
