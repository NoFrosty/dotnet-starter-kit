using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.English.Exceptions;
public sealed class HeartNotFoundException : NotFoundException
{
    public HeartNotFoundException(Guid id)
        : base($"heart with playerid {id} not found")
    {
    }
}
