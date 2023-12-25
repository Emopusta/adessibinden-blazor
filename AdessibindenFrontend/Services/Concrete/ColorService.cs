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
        
        public async Task<GetListResponse<GetAllColorsListItemDto>> GetAll()
        {


            var response = await _httpClient.GetFromJsonAsync<GetListResponse<GetAllColorsListItemDto>>("/api/Colors?PageIndex=0&PageSize=10");

            return response;

        }
    }
}
