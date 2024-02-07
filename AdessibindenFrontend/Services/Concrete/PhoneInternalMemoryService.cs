using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class PhoneInternalMemoryService : IPhoneInternalMemoryService
{
    private readonly HttpClient _httpClient;

    public PhoneInternalMemoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IRequestResult<ListResponse<GetAllListPhoneInternalMemoryDto>>> GetAll()
    {
        var response = await _httpClient.GetAsync($"/api/PhoneInternalMemories");
        var result = response.Content.ReadFromJsonAsync<RequestResult<ListResponse<GetAllListPhoneInternalMemoryDto>>>().Result;
        return result;
    }
}
