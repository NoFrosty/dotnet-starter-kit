using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Features.Get.v1;
public sealed class GetCardHandler(
    [FromKeyedServices("english:cards")] IRepository<CardItem> repository)
    : IRequestHandler<GetCardRequest, GetCardResponse>
{
    public async Task<GetCardResponse> Handle(GetCardRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var cardItem = await repository.FirstOrDefaultAsync(new EntitiesByPlayerIdSpec<CardItem>(request.PlayerId), cancellationToken);
        if (cardItem == null) throw new CardNotFoundException(request.PlayerId);
        return new GetCardResponse(cardItem.UnlockedCards);
    }
}
