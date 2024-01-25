using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IColorService
    {
        public Task<RequestResult<PaginateResponse<GetAllColorsListItemDto>>> GetAll(int pageIndex, int pageSize);
    
    }
}
