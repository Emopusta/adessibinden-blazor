using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneBrandService
    {
        Task<IRequestResult<List<GetAllListPhoneBrandDto>>> GetAll();

    }
}
