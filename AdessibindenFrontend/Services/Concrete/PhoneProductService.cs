using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using Application.Features.UserProfiles.Commands.Create;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneProductService : IPhoneProductService
    {
        private readonly HttpClient _httpClient;
        readonly NavigationManager _navigationManager;

        public PhoneProductService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<IRequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/PhoneProducts", payload);
            var result = response.Content.ReadFromJsonAsync<RequestResult<CreatedPhoneProductResponse>>().Result;
            return result;
        }

        public async Task<IRequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/PhoneProducts/{productId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetByIdDetailsPhoneProductResponse>>().Result;
            if (!result.Success) { _navigationManager.NavigateTo("/not-found"); }
            return result;
        }

        public async Task<IRequestResult<GetAllPhoneProductFeaturesDto>> GetFeatures()
        {

            var response = await _httpClient.GetAsync("/api/PhoneProducts");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetAllPhoneProductFeaturesDto>>().Result;
            if (!result.Success) { _navigationManager.NavigateTo("/not-found"); }
            return result;

        }
    }
}
