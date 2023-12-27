using AdessibindenFrontend.Services.Abstract;
using Application.Features.Colors.Queries.GetAll;
using Core.Application.Responses;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<RequestResult<GetListResponse<GetAllColorsListItemDto>>> GetAll(int pageIndex, int pageSize)
        {


            var response = await _httpClient.GetFromJsonAsync<RequestResult<GetListResponse<GetAllColorsListItemDto>>>($"/api/Colors?PageIndex={pageIndex}&PageSize={pageSize}");

            return response;

        }
    }
}
