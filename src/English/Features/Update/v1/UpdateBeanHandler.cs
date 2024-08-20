using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed class UpdateBeanHandler(
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository,
    ILogger<UpdateBeanHandler> logger)
    : IRequestHandler<UpdateBeanCommand, UpdateBeanResponse>
{
    public async Task<UpdateBeanResponse> Handle(UpdateBeanCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var bean = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<BeanItem>(request.PlayerId), cancellationToken);
        _ = bean ?? throw new BeanNotFoundException(request.PlayerId);
        var updatedBean = bean.Update(request.AmountOfBeanMuzzy, request.AmountOfBeanBurn, request.AmountOfBeanCube, request.AmountOfBeanRoxy, request.AmountOfBeanOllie, request.AmountOfBeanNova, request.AmountOfBeanBeebee, request.AmountOfBeanLuna, request.AmountOfBeanFurry);
        await repository.UpdateAsync(updatedBean, cancellationToken);
        logger.LogInformation("bean with PlayerId : {PlayerId} updated.", bean.PlayerId);
        return new UpdateBeanResponse(bean.PlayerId);
    }
}
