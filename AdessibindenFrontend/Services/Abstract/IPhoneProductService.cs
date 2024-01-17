using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Commands.Update;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<IRequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int productId);
        Task<IRequestResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdDetailsForUpdate(int productId);
        Task<IRequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload);
        Task<IRequestResult<UpdatedPhoneProductResponse>> UpdatePhoneProduct(UpdatePhoneProductDto payload);
    }
}
