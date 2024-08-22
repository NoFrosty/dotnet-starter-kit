using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Search.v1;
public record SearchHeartsCommand(PaginationFilter filter) : IRequest<PagedList<GetHeartResponse>>;
