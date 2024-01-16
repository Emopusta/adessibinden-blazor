using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneRAMService
    {
        Task<IRequestResult<List<GetAllListPhoneRAMDto>>> GetAll();

    }
}
