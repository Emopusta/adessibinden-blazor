using AdessibindenFrontend.Core.Application.Requests;
using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;


namespace AdessibindenFrontend.Services.Abstract
{
    public interface IProductService
    {
        public Task<IRequestResult<PaginateResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserIdPaginated(PageRequest pageRequest, int creatorUserId);

    }
}
