using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Search.v1;
public sealed class SearchCardsHandler(
    [FromKeyedServices("english:cards")] IReadRepository<CardItem> repository)
    : IRequestHandler<SearchCardsCommand, PagedList<GetCardResponse>>
{
    public async Task<PagedList<GetCardResponse>> Handle(SearchCardsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new EntitiesByPaginationFilterSpec<CardItem, GetCardResponse>(request.Filter);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<GetCardResponse>(items, request.Filter.PageNumber, request.Filter.PageSize, totalCount);
    }
}
