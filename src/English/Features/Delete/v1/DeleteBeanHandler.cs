using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Delete.v1;
public sealed class DeleteBeanHandler(
    ILogger<DeleteBeanHandler> logger,
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository)
    : IRequestHandler<DeleteBeanCommand>
{
    public async Task Handle(DeleteBeanCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var bean = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<BeanItem>(request.PlayerId), cancellationToken);
        _ = bean ?? throw new BeanNotFoundException(request.PlayerId);
        await repository.DeleteAsync(bean, cancellationToken);
        logger.LogInformation("bean with id : {BeanId} deleted", bean.Id);
    }
}
