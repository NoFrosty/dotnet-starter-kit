using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class ProgressItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities
{
    public Guid PlayerId { get; set; }
    public int Unit1Progress { get; set; }
    public int Unit2Progress { get; set; }
    public int Unit3Progress { get; set; }
    public int Unit4Progress { get; set; }
    public int Unit5Progress { get; set; }
    public int Unit6Progress { get; set; }
    public int Unit7Progress { get; set; }

    public static ProgressItem Create(Guid playerId, int unit1Progress, int unit2Progress, int unit3Progress, int unit4Progress, int unit5Progress, int unit6Progress, int unit7Progress)
    {
        var item = new ProgressItem();

        item.PlayerId = playerId;
        item.Unit1Progress = unit1Progress;
        item.Unit2Progress = unit2Progress;
        item.Unit3Progress = unit3Progress;
        item.Unit4Progress = unit4Progress;
        item.Unit5Progress = unit5Progress;
        item.Unit6Progress = unit6Progress;
        item.Unit7Progress = unit7Progress;

        item.QueueDomainEvent(new ProgressItemCreated(item.Id, item.PlayerId, item.Unit1Progress, item.Unit2Progress, item.Unit3Progress, item.Unit4Progress, item.Unit5Progress, item.Unit6Progress, item.Unit7Progress));

        return item;
    }

    public ProgressItem Update(int unit1Progress, int unit2Progress, int unit3Progress, int unit4Progress, int unit5Progress, int unit6Progress, int unit7Progress)
    {
        if (Unit1Progress != unit1Progress) Unit1Progress = unit1Progress;
        if (Unit2Progress != unit2Progress) Unit2Progress = unit2Progress;
        if (Unit3Progress != unit3Progress) Unit3Progress = unit3Progress;
        if (Unit4Progress != unit4Progress) Unit4Progress = unit4Progress;
        if (Unit5Progress != unit5Progress) Unit5Progress = unit5Progress;
        if (Unit6Progress != unit6Progress) Unit6Progress = unit6Progress;
        if (Unit7Progress != unit7Progress) Unit7Progress = unit7Progress;

        this.QueueDomainEvent(new ProgressItemUpdated(this));

        return this;

    }
}
