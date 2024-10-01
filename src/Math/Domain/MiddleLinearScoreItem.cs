using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Math.Domain.Events;

namespace FSH.Starter.WebApi.Math.Domain;
public class MiddleLinearScoreItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities, IPlayerScoreEntities
{
    public Guid PlayerId { get; set; }
    public int Score { get; set; }

    public static MiddleLinearScoreItem Create(Guid playerId, int score)
    {
        var item = new MiddleLinearScoreItem();

        item.PlayerId = playerId;
        item.Score = score;

        item.QueueDomainEvent(new MiddleLinearScoreItemCreated(item.Id, item.PlayerId, item.Score));

        return item;
    }

    public MiddleLinearScoreItem Update(int score)
    {
        if (Score != score) Score = score;

        this.QueueDomainEvent(new MiddleLinearScoreItemUpdated(this));

        return this;
    }
}
