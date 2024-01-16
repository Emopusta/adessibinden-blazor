using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneRAMService : IPhoneRAMService
    {
        private readonly HttpClient _httpClient;

        public PhoneRAMService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<List<GetAllListPhoneRAMDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/PhoneRAMs");
            var result = response.Content.ReadFromJsonAsync<RequestResult<List<GetAllListPhoneRAMDto>>>().Result;
            return result;
        }
    }
}
