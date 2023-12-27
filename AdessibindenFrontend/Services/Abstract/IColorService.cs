using Application.Features.Colors.Queries.GetAll;
using Core.Application.Responses;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IColorService
    {
        public Task<RequestResult<GetListResponse<GetAllColorsListItemDto>>> GetAll(int pageIndex, int pageSize);
    
    }
}
