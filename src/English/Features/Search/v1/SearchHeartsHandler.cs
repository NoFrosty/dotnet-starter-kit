using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Search.v1;
public sealed class SearchHeartsHandler(
    [FromKeyedServices("english:hearts")] IReadRepository<HeartItem> repository)
    : IRequestHandler<SearchHeartsCommand, PagedList<GetHeartResponse>>
{
    public async Task<PagedList<GetHeartResponse>> Handle(SearchHeartsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new EntitiesByPaginationFilterSpec<HeartItem, GetHeartResponse>(request.filter);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<GetHeartResponse>(items, request.filter.PageNumber, request.filter.PageSize, totalCount);
    }
}
