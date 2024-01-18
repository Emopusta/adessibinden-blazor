using AdessibindenFrontend.Services.Results;
using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
using Core.Application.Requests;
using Core.Application.Responses;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IProductService
    {
        public Task<IRequestResult<GetListResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserIdPaginated(PageRequest pageRequest, int creatorUserId);

    }
}
