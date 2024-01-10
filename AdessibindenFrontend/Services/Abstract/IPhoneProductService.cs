using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<RequestResult<GetAllPhoneProductFeaturesDto>> GetAll();
        Task<RequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload);
    }
}
