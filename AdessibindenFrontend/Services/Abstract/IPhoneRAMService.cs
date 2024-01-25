using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IPhoneRAMService
    {
        Task<IRequestResult<List<GetAllListPhoneRAMDto>>> GetAll();

    }
}
