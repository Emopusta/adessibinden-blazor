using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<RequestResult<GetAllPhoneProductFeaturesDto>> GetFeatures();
        Task<RequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int id);
        Task<RequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload);
    }
}
