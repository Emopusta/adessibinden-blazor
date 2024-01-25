using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;


namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneProductService
    {
        Task<IRequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int productId);
        Task<IRequestResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdDetailsForUpdate(int productId);
        Task<IRequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload);
        Task<IRequestResult<UpdatedPhoneProductResponse>> UpdatePhoneProduct(UpdatePhoneProductDto payload);
        Task<IRequestResult<DeletedPhoneProductResponse>> DeletePhoneProduct(int productId);
    }
}
