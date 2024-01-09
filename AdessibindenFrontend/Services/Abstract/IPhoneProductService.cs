using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Dtos;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<RequestResult<GetAllPhoneProductFeaturesDto>> GetAll();
    }
}
