using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class ProductCategoryService : IProductCategoryService
{
    private readonly HttpClient _httpClient;

    public ProductCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RequestResult<ListResponse<GetAllListProductCategoryDto>>> GetAll()
    {
        var response = await _httpClient.GetAsync($"/api/ProductCategories");
        var result = response.Content.ReadFromJsonAsync<RequestResult<ListResponse<GetAllListProductCategoryDto>>>().Result;
        return result;
    }
}
