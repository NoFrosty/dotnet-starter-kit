using FSH.Framework.Core.Persistence;
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
        var bean = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = bean ?? throw new BeanNotFoundException(request.Id);
        var updatedBean = bean.Update(request.AmountOfBean);
        await repository.UpdateAsync(updatedBean, cancellationToken);
        logger.LogInformation("bean with id : {BeanId} updated.", bean.Id);
        return new UpdateBeanResponse(bean.Id);
    }
}
