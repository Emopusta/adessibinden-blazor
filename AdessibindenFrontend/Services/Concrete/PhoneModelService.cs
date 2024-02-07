using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete;

public class PhoneModelService : IPhoneModelService
{
    private readonly HttpClient _httpClient;

    public PhoneModelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IRequestResult<ListResponse<GetByBrandIdPhoneModelDto>>> GetByBrandId(int brandId)
    {
        var response = await _httpClient.GetAsync($"/api/PhoneModels/{brandId}");
        var result = response.Content.ReadFromJsonAsync<RequestResult<ListResponse<GetByBrandIdPhoneModelDto>>>().Result;
        return result;
    }
}
