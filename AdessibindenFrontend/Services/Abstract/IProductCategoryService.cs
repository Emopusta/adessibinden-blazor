using AdessibindenFrontend.Services.Results;
using Application.Features.ProductCategories.Queries.GetAllList;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IProductCategoryService
    {
        Task<RequestResult<List<GetAllListProductCategoryDto>>> GetAll();

    }
}
