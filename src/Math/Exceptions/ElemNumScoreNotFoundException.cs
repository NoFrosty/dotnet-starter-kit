using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Math.Exceptions;
public sealed class ElemNumScoreNotFoundException : NotFoundException
{
    public ElemNumScoreNotFoundException(Guid id)
        : base($"elemnumscore with playerid {id} not found")
    {
    }
}
