using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<IRequestResult<GetAllPhoneProductFeaturesDto>> GetFeatures();
        Task<IRequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int productId);
        Task<IRequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload);
    }
}
