using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class BeanItem : AuditableEntity, IAggregateRoot
{
    public Guid PlayerId { get; set; }
    public Guid NpcId { get; set; }
    public int AmountOfBean { get; set; }

    public static BeanItem Create(Guid playerId, Guid npcId, int amountOfBean)
    {
        var item = new BeanItem();

        item.PlayerId = playerId;
        item.NpcId = npcId;
        item.AmountOfBean = amountOfBean;

        item.QueueDomainEvent(new BeanItemCreated(item.Id, item.PlayerId, item.NpcId, item.AmountOfBean));

        return item;
    }

    public BeanItem Update(int amountOfBean)
    {
        if (AmountOfBean != amountOfBean) AmountOfBean = amountOfBean;

        this.QueueDomainEvent(new BeanItemUpdated(this));

        return this;

    }

    public BeanItem Increase(int amountOfBean)
    {
        AmountOfBean += amountOfBean;

        this.QueueDomainEvent(new BeanItemIncreased(this));

        return this;
    }
}
