using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.English.Domain;
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

        if (cardItem == null)
        {
            cardItem = CardItem.Create(request.PlayerId, new Dictionary<string, List<bool>>());
            await repository.AddAsync(cardItem, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }

        return new GetCardResponse(cardItem.UnlockedCards);
    }
}
