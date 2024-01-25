using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpClient;

        public ProductCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
  
        public async Task<RequestResult<List<GetAllListProductCategoryDto>>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<RequestResult<List<GetAllListProductCategoryDto>>>($"/api/ProductCategories");
            return response;
        }
    }
}
