using Application.Features.Colors.Queries.GetAll;
using Core.Application.Responses;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IColorService
    {
        public Task<GetListResponse<GetAllColorsListItemDto>> GetAll();
    
    }
}
