using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class PhoneInternalMemoryService : IPhoneInternalMemoryService
    {
        private readonly HttpClient _httpClient;

        public PhoneInternalMemoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<List<GetAllListPhoneInternalMemoryDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/PhoneInternalMemories");
            var result = response.Content.ReadFromJsonAsync<RequestResult<List<GetAllListPhoneInternalMemoryDto>>>().Result;
            return result;
        }
    }
}
