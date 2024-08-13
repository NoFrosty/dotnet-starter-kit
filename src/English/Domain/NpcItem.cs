using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class NpcItem : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = default!;

    public static NpcItem Create(string name)
    {
        var item = new NpcItem();

        item.Name = name;

        item.QueueDomainEvent(new NpcItemCreated(item.Id, item.Name));

        return item;
    }

    public NpcItem Update(string name)
    {
        if (name is not null && Name?.Equals(name, StringComparison.OrdinalIgnoreCase) is not true) Name = name;

        this.QueueDomainEvent(new NpcItemUpdated(this));

        return this;

    }
}
