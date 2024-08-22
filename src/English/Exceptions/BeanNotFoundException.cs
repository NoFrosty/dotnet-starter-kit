using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.English.Exceptions;
public sealed class BeanNotFoundException : NotFoundException
{
    public BeanNotFoundException(Guid id)
        : base($"bean with playerid {id} not found")
    {
    }
}
