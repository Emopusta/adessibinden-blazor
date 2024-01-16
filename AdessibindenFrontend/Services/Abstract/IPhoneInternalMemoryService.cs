using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneInternalMemoryService
    {
        Task<IRequestResult<List<GetAllListPhoneInternalMemoryDto>>> GetAll();

    }
}
