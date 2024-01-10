using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Commands.Create;
using Application.Features.PhoneProducts.Dtos;
using Application.Features.UserProfiles.Commands.Create;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneProductService : IPhoneProductService
    {
        private readonly HttpClient _httpClient;

        public PhoneProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RequestResult<CreatedPhoneProductResponse>> CreatePhoneProduct(AddPhoneProductDto payload)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/PhoneProducts", payload);
            var result = response.Content.ReadFromJsonAsync<RequestResult<CreatedPhoneProductResponse>>().Result;
            return result;
        }

        public async Task<RequestResult<GetAllPhoneProductFeaturesDto>> GetAll()
        {
            
            var response = await _httpClient.GetFromJsonAsync<RequestResult<GetAllPhoneProductFeaturesDto>>($"/api/PhoneProducts");
            return response;

        }
    }
}
