using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProducts.Dtos;
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

        public async Task<RequestResult<GetAllPhoneProductFeaturesDto>> GetAll()
        {
            
            var response = await _httpClient.GetFromJsonAsync<RequestResult<GetAllPhoneProductFeaturesDto>>($"/api/PhoneProducts");
            return response;

        }
    }
}
