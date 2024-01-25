using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneBrandService
    {
        Task<IRequestResult<List<GetAllListPhoneBrandDto>>> GetAll();

    }
}
