using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Math.Exceptions;
public sealed class ProgressNotFoundException : NotFoundException
{
    public ProgressNotFoundException(Guid id)
        : base($"progress with playerid {id} not found")
    {
    }
}
