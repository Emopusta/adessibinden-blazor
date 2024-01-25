using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneInternalMemoryService
    {
        Task<IRequestResult<List<GetAllListPhoneInternalMemoryDto>>> GetAll();

    }
}
