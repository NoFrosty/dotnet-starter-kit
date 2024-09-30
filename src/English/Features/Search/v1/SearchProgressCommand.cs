using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.English.Features.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.English.Features.Search.v1;
public record SearchProgressCommand(PaginationFilter filter) :
    IRequest<PagedList<GetProgressResponse>>;
