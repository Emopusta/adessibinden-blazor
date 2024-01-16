using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneModelService
    {
        Task<IRequestResult<List<GetByBrandIdPhoneModelDto>>> GetByBrandId(int brandId);
        
    }
}
