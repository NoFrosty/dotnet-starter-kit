using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateBeanHandler(
    ILogger<CreateBeanHandler> logger,
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository)
    : IRequestHandler<CreateBeanCommand, CreateBeanResponse>
{
    public async Task<CreateBeanResponse> Handle(CreateBeanCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var bean = BeanItem.Create((Guid)request.PlayerId!, (int)request.AmountOfBeanMuzzy!, (int)request.AmountOfBeanBurn!, (int)request.AmountOfBeanCube!, (int)request.AmountOfBeanRoxy!, (int)request.AmountOfBeanOllie!, (int)request.AmountOfBeanNova!, (int)request.AmountOfBeanBeebee!, (int)request.AmountOfBeanLuna!, (int)request.AmountOfBeanFurry!);
        await repository.AddAsync(bean, cancellationToken);
        logger.LogInformation("bean created {BeanId}", bean.Id);
        return new CreateBeanResponse(bean.Id);
    }
}
