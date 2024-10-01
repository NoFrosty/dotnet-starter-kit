using Ardalis.Specification;
using FSH.Framework.Core.Paging;

namespace FSH.Framework.Core.Specifications;

public class EntitiesByBaseFilterSpec<T, TResult> : Specification<T, TResult>
{
    public EntitiesByBaseFilterSpec(BaseFilter filter) =>
        Query.SearchBy(filter);
}

public class EntitiesByBaseFilterSpec<T> : Specification<T>
{
    public EntitiesByBaseFilterSpec(BaseFilter filter) =>
        Query.SearchBy(filter);
}

public class EntitiesByPlayerIdSpec<T> : Specification<T> where T : IPlayerLinkedEntities
{
    public EntitiesByPlayerIdSpec(Guid playerId)
    {
        Query.Where(x => x.PlayerId == playerId);
    }
}

public class EntitiesWithScoreGreaterThanSpec<T> : Specification<T> where T : IPlayerScoreEntities
{
    public EntitiesWithScoreGreaterThanSpec(int score)
    {
        Query.Where(x => x.Score > score);
    }
}

public class Top10EntitiesOrderedByScoreSpec<T> : Specification<T> where T : IPlayerScoreEntities
{
    public Top10EntitiesOrderedByScoreSpec()
    {
        Query.OrderByDescending(x => x.Score).Take(10);
    }
}
