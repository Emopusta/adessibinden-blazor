using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
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
    }
}
