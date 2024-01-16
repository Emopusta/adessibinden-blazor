using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneModels.Queries.GetByBrandId;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneModelService : IPhoneModelService
    {
        private readonly HttpClient _httpClient;

        public PhoneModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<List<GetByBrandIdPhoneModelDto>>> GetByBrandId(int brandId)
        {
            var response = await _httpClient.GetAsync($"/api/PhoneModels/{brandId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<List<GetByBrandIdPhoneModelDto>>>().Result;
            return result;
        }
    }
}
