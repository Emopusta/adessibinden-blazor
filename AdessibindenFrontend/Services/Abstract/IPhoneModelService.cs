using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneModelService
    {
        Task<IRequestResult<ListResponse<GetByBrandIdPhoneModelDto>>> GetByBrandId(int brandId);
        
    }
}
