using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract;

public interface IPhoneRAMService
{
    Task<IRequestResult<ListResponse<GetAllListPhoneRAMDto>>> GetAll();
}