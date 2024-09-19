using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.English.Exceptions;
public sealed class CardNotFoundException : NotFoundException
{
    public CardNotFoundException(Guid id)
        : base($"card with playerid {id} not found")
    {
    }
}
