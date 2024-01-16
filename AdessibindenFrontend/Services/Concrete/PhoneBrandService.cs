using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneBrands.Queries.GetAllList;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneBrandService : IPhoneBrandService
    {
        private readonly HttpClient _httpClient;

        public PhoneBrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<List<GetAllListPhoneBrandDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/PhoneBrands");
            var result = response.Content.ReadFromJsonAsync<RequestResult<List<GetAllListPhoneBrandDto>>>().Result;
            return result;
        }
    }
}
