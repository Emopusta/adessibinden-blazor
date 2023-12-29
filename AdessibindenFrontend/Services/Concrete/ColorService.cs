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

        public async Task<RequestResult<GetListResponse<GetAllColorsListItemDto>>> GetAll(int pageIndex, int pageSize)
        {

            //try
            //{
            var response = await _httpClient.GetFromJsonAsync<RequestResult<GetListResponse<GetAllColorsListItemDto>>>($"/api/Colors?PageIndex={pageIndex}&PageSize={pageSize}");
            return response;

            //}
            //catch (Exception e)
            //{
            //    return  new RequestResult<GetListResponse<GetAllColorsListItemDto>>() { Message = e.Message.ToString() };
            //}


        }
    }
}
