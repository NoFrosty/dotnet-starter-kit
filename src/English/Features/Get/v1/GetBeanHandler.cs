using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public sealed class GetBeanHandler(
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository,
    ICacheService cache)
    : IRequestHandler<GetBeanRequest, GetBeanResponse>
{
    public async Task<GetBeanResponse> Handle(GetBeanRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"bean:{request.Id}",
            async () =>
            {
                var beanItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (beanItem == null) throw new BeanNotFoundException(request.Id);
                return new GetBeanResponse(beanItem.Id, beanItem.PlayerId, beanItem.NpcId, beanItem.AmountOfBean);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
