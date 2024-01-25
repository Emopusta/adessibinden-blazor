using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ColorService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<RequestResult<PaginateResponse<GetAllColorsListItemDto>>> GetAll(int pageIndex, int pageSize)
        {

            var response = await _httpClient.GetFromJsonAsync<RequestResult<PaginateResponse<GetAllColorsListItemDto>>>($"/api/Colors?PageIndex={pageIndex}&PageSize={pageSize}");
            return response;

        }
    }
}
