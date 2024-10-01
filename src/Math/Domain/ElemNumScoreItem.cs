using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain.Events;

namespace FSH.Starter.WebApi.Math.Domain;
public class ElemNumScoreItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities, IPlayerScoreEntities
{
    public Guid PlayerId { get; set; }
    public int Score { get; set; }

    public static ElemNumScoreItem Create(Guid playerId, int score)
    {
        var item = new ElemNumScoreItem();

        item.PlayerId = playerId;
        item.Score = score;

        item.QueueDomainEvent(new ElemNumScoreItemCreated(item.Id, item.PlayerId, item.Score));

        return item;
    }

    public ElemNumScoreItem Update(int score)
    {
        if (Score != score) Score = score;

        this.QueueDomainEvent(new ElemNumScoreItemUpdated(this));

        return this;
    }
}
