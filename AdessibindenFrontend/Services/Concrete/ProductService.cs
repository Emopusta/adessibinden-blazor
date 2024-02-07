using AdessibindenFrontend.Core.Application.Requests;
using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IRequestResult<PaginateResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserIdPaginated(PageRequest pageRequest, int creatorUserId)
    {
        var response = await _httpClient.GetFromJsonAsync<RequestResult<PaginateResponse<GetByCreatorUserIdPaginatedDto>>>($"/api/Products/GetByCreator/{creatorUserId}?PageIndex={pageRequest.PageIndex}&PageSize={pageRequest.PageSize}");
            return response;
    }

    public async Task<IRequestResult<PaginateResponse<PaginatedProductDto>>> GetAllPaginated(PageRequest pageRequest)
    {
        var response = await _httpClient.GetFromJsonAsync<RequestResult<PaginateResponse<PaginatedProductDto>>>($"/api/Products?PageIndex={pageRequest.PageIndex}&PageSize={pageRequest.PageSize}");
        return response;
    }

    public async Task<IRequestResult<PaginateResponse<PaginatedProductDto>>> GetByTitlePaginated(PageRequest pageRequest, string productTitleToSearch)
    {
        var response = await _httpClient.GetFromJsonAsync<RequestResult<PaginateResponse<PaginatedProductDto>>>($"/api/Products/GetByTitle?PageIndex={pageRequest.PageIndex}&PageSize={pageRequest.PageSize}&productTitleToSearch={productTitleToSearch}");
        return response;
    }
}
