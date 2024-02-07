using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class PhoneBrandService : IPhoneBrandService
{
    private readonly HttpClient _httpClient;

    public PhoneBrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IRequestResult<ListResponse<GetAllListPhoneBrandDto>>> GetAll()
    {
        var response = await _httpClient.GetAsync($"/api/PhoneBrands");
        var result = response.Content.ReadFromJsonAsync<RequestResult<ListResponse<GetAllListPhoneBrandDto>>>().Result;
        return result;
    }
}
