using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public sealed class GetBeanHandler(
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository)
    : IRequestHandler<GetBeanRequest, GetBeanResponse>
{
    public async Task<GetBeanResponse> Handle(GetBeanRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var beanItem = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<BeanItem>(request.PlayerId), cancellationToken);

        if (beanItem == null) throw new BeanNotFoundException(request.PlayerId);
        return new GetBeanResponse(beanItem.AmountOfBeanMuzzy, beanItem.AmountOfBeanBurn, beanItem.AmountOfBeanCube, beanItem.AmountOfBeanRoxy, beanItem.AmountOfBeanOllie, beanItem.AmountOfBeanNova, beanItem.AmountOfBeanBeebee, beanItem.AmountOfBeanLuna, beanItem.AmountOfBeanFurry);
    }
}
