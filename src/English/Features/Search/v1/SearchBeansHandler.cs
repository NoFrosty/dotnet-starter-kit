using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Search.v1;
public sealed class SearchBeansHandler(
[FromKeyedServices("english:beans")] IReadRepository<BeanItem> repository)
    : IRequestHandler<SearchBeansCommand, PagedList<GetBeanResponse>>
{
    public async Task<PagedList<GetBeanResponse>> Handle(SearchBeansCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new EntitiesByPaginationFilterSpec<BeanItem, GetBeanResponse>(request.filter);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<GetBeanResponse>(items, request.filter.PageNumber, request.filter.PageSize, totalCount);
    }
}
