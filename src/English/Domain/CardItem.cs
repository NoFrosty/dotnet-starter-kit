using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class CardItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities
{
    public Guid PlayerId { get; set; }
    public Dictionary<string, List<bool>> UnlockedCards { get; } = new Dictionary<string, List<bool>>();

    public static CardItem Create(Guid playerId, Dictionary<string, List<bool>> unlockedCards)
    {
        var item = new CardItem();
        item.PlayerId = playerId;
        foreach (var (key, value) in unlockedCards)
        {

            if (!item.UnlockedCards.TryAdd(key, value))
            {
                item.UnlockedCards[key] = value;
            }
        }

        item.QueueDomainEvent(new CardItemCreated(item.Id, item.PlayerId, item.UnlockedCards));

        return item;
    }

    public CardItem Update(Dictionary<string, List<bool>> unlockedCards)
    {
        foreach (var (key, value) in unlockedCards)
        {

            if (!UnlockedCards.TryAdd(key, value))
            {
                UnlockedCards[key] = value;
            }
        }
        this.QueueDomainEvent(new CardItemUpdated(this));

        return this;
    }
}
