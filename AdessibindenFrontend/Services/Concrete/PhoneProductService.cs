using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;
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

        public async Task<IRequestResult<DeletedPhoneProductResponse>> DeletePhoneProduct(int productId)
        {
            var response = await _httpClient.DeleteFromJsonAsync<RequestResult<DeletedPhoneProductResponse>>($"/api/PhoneProducts/{productId}");
            return response;
        }

        public async Task<IRequestResult<GetByIdDetailsPhoneProductResponse>> GetByIdDetails(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/PhoneProducts/{productId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetByIdDetailsPhoneProductResponse>>().Result;
            if (!result.Success) { _navigationManager.NavigateTo("/not-found"); }
            return result;
        }
        public async Task<IRequestResult<GetByIdDetailsForUpdatePhoneProductResponse>> GetByIdDetailsForUpdate(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/PhoneProducts/UpdateDetails/{productId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetByIdDetailsForUpdatePhoneProductResponse>>().Result;
            if (!result.Success) { _navigationManager.NavigateTo("/not-found"); }
            return result;
        }

        public async Task<IRequestResult<UpdatedPhoneProductResponse>> UpdatePhoneProduct(UpdatePhoneProductDto payload)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/PhoneProducts", payload);
            var result = response.Content.ReadFromJsonAsync<RequestResult<UpdatedPhoneProductResponse>>().Result;
            return result;
        }
    }
}
