using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain.Events;

namespace FSH.Starter.WebApi.English.Domain;
public class BeanItem : AuditableEntity, IAggregateRoot, IPlayerLinkedEntities
{
    public Guid PlayerId { get; set; }
    public int AmountOfBeanMuzzy { get; set; }
    public int AmountOfBeanBurn { get; set; }
    public int AmountOfBeanCube { get; set; }
    public int AmountOfBeanRoxy { get; set; }
    public int AmountOfBeanOllie { get; set; }
    public int AmountOfBeanNova { get; set; }
    public int AmountOfBeanBeebee { get; set; }
    public int AmountOfBeanLuna { get; set; }
    public int AmountOfBeanFurry { get; set; }

    public static BeanItem Create(Guid playerId, int amountOfBeanMuzzy, int amountOfBeanBurn, int amountOfBeanCube, int amountOfBeanRoxy, int amountOfBeanOllie, int amountOfBeanNova, int amountOfBeanBeebee, int amountOfBeanLuna, int amountOfBeanFurry)
    {
        var item = new BeanItem();

        item.PlayerId = playerId;
        item.AmountOfBeanMuzzy = amountOfBeanMuzzy;
        item.AmountOfBeanBurn = amountOfBeanBurn;
        item.AmountOfBeanCube = amountOfBeanCube;
        item.AmountOfBeanRoxy = amountOfBeanRoxy;
        item.AmountOfBeanOllie = amountOfBeanOllie;
        item.AmountOfBeanNova = amountOfBeanNova;
        item.AmountOfBeanBeebee = amountOfBeanBeebee;
        item.AmountOfBeanLuna = amountOfBeanLuna;
        item.AmountOfBeanFurry = amountOfBeanFurry;

        item.QueueDomainEvent(new BeanItemCreated(item.Id, item.PlayerId, item.AmountOfBeanMuzzy, item.AmountOfBeanBurn, item.AmountOfBeanCube, item.AmountOfBeanRoxy, item.AmountOfBeanOllie, item.AmountOfBeanNova, item.AmountOfBeanBeebee, item.AmountOfBeanLuna, item.AmountOfBeanFurry));

        return item;
    }

    public BeanItem Update(int amountOfBeanMuzzy, int amountOfBeanBurn, int amountOfBeanCube, int amountOfBeanRoxy, int amountOfBeanOllie, int amountOfBeanNova, int amountOfBeanBeebee, int amountOfBeanLuna, int amountOfBeanFurry)
    {
        if (AmountOfBeanMuzzy != amountOfBeanMuzzy) AmountOfBeanMuzzy = amountOfBeanMuzzy;
        if (AmountOfBeanBurn != amountOfBeanBurn) AmountOfBeanBurn = amountOfBeanBurn;
        if (AmountOfBeanCube != amountOfBeanCube) AmountOfBeanCube = amountOfBeanCube;
        if (AmountOfBeanRoxy != amountOfBeanRoxy) AmountOfBeanRoxy = amountOfBeanRoxy;
        if (AmountOfBeanOllie != amountOfBeanOllie) AmountOfBeanOllie = amountOfBeanOllie;
        if (AmountOfBeanNova != amountOfBeanNova) AmountOfBeanNova = amountOfBeanNova;
        if (AmountOfBeanBeebee != amountOfBeanBeebee) AmountOfBeanBeebee = amountOfBeanBeebee;
        if (AmountOfBeanLuna != amountOfBeanLuna) AmountOfBeanLuna = amountOfBeanLuna;
        if (AmountOfBeanFurry != amountOfBeanFurry) AmountOfBeanFurry = amountOfBeanFurry;

        this.QueueDomainEvent(new BeanItemUpdated(this));

        return this;
    }
}
