using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Math.Exceptions;
public sealed class ScoreNotFoundException : NotFoundException
{
    public ScoreNotFoundException(Guid id)
        : base($"score with playerid {id} not found")
    {
    }
}
