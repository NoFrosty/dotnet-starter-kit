using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class HeartItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities
{
    public Guid PlayerId { get; set; }
    public int AmountOfHeart { get; set; }

    public static HeartItem Create(Guid playerId, int amountOfHeart)
    {
        var item = new HeartItem();

        item.PlayerId = playerId;
        item.AmountOfHeart = amountOfHeart;

        item.QueueDomainEvent(new HeartItemCreated(item.Id, item.PlayerId, item.AmountOfHeart));

        return item;
    }

    public HeartItem Update(int amountOfHeart)
    {
        if (AmountOfHeart != amountOfHeart) AmountOfHeart = amountOfHeart;

        this.QueueDomainEvent(new HeartItemUpdated(this));

        return this;

    }

    public HeartItem Increase(int amountOfHeart)
    {
        AmountOfHeart += amountOfHeart;

        this.QueueDomainEvent(new HeartItemIncreased(this));

        return this;
    }
}
