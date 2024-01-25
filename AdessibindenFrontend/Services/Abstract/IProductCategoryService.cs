using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IProductCategoryService
    {
        Task<RequestResult<List<GetAllListProductCategoryDto>>> GetAll();

    }
}
