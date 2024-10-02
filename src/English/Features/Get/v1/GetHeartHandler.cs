using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public sealed class GetHeartHandler(
    [FromKeyedServices("english:hearts")] IRepository<HeartItem> repository)
    : IRequestHandler<GetHeartRequest, GetHeartResponse>
{
    public async Task<GetHeartResponse> Handle(GetHeartRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var heartItem = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<HeartItem>(request.PlayerId), cancellationToken);

        if (heartItem == null)
        {
            heartItem = HeartItem.Create(request.PlayerId, 0);
            await repository.AddAsync(heartItem, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        return new GetHeartResponse(heartItem.AmountOfHeart);
    }
}
