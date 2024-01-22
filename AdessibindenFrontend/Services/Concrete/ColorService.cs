using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.Colors.Queries.GetAll;
using Core.Application.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Newtonsoft.Json;
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
