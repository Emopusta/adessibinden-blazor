using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class PhoneRAMService : IPhoneRAMService
{
    private readonly HttpClient _httpClient;

    public PhoneRAMService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IRequestResult<ListResponse<GetAllListPhoneRAMDto>>> GetAll()
    {
        var response = await _httpClient.GetAsync($"/api/PhoneRAMs");
        var result = response.Content.ReadFromJsonAsync<RequestResult<ListResponse<GetAllListPhoneRAMDto>>>().Result;
        return result;
    }
}
