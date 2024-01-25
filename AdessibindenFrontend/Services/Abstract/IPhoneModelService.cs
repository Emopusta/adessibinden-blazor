using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneModelService
    {
        Task<IRequestResult<List<GetByBrandIdPhoneModelDto>>> GetByBrandId(int brandId);
        
    }
}
