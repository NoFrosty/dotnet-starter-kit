using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
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
        if (heartItem == null) throw new HeartNotFoundException(request.PlayerId);
        return new GetHeartResponse(heartItem.AmountOfHeart);
    }
}
