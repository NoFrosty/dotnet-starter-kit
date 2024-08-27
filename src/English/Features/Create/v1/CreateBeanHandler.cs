using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed class CreateBeanHandler(
    ILogger<CreateBeanHandler> logger,
    [FromKeyedServices("english:beans")] IRepository<BeanItem> repository)
    : IRequestHandler<CreateBeanCommandPlayerId, CreateBeanResponse>
{
    public async Task<CreateBeanResponse> Handle(CreateBeanCommandPlayerId request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var bean = BeanItem.Create(request.PlayerId!, (int)request.Data.AmountOfBeanMuzzy!, (int)request.Data.AmountOfBeanBurn!, (int)request.Data.AmountOfBeanCube!, (int)request.Data.AmountOfBeanRoxy!, (int)request.Data.AmountOfBeanOllie!, (int)request.Data.AmountOfBeanNova!, (int)request.Data.AmountOfBeanBeebee!, (int)request.Data.AmountOfBeanLuna!, (int)request.Data.AmountOfBeanFurry!);
        await repository.AddAsync(bean, cancellationToken);
        logger.LogInformation("bean created {BeanId}", bean.Id);
        return new CreateBeanResponse(bean.Id);
    }
}
