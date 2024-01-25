using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{
    public class UserFavouriteProductService : IUserFavouriteProductService
    {
        private readonly HttpClient _httpClient;

        public UserFavouriteProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<CreatedUserFavouriteProductResponse>> AddFavourites(CreateUserFavouriteProductDto createUserFavouriteProductDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/UserFavouriteProducts", createUserFavouriteProductDto);
            var result = response.Content.ReadFromJsonAsync<RequestResult<CreatedUserFavouriteProductResponse>>().Result;
            return result;
        }

        public async Task<IRequestResult<DeletedUserFavouriteProductResponse>> DeleteFavourites(DeleteUserFavouriteProductDto deleteUserFavouriteProductDto)
        {
            var response = await _httpClient.DeleteFromJsonAsync<RequestResult<DeletedUserFavouriteProductResponse>>($"/api/UserFavouriteProducts/{deleteUserFavouriteProductDto.UserId}/{deleteUserFavouriteProductDto.ProductId}");
            return response;
        }

        public async Task<IRequestResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetCurrentFavouriteByUserIdAndProductId(GetByProductAndUserIdFavouriteProductDto getByProductAndUserIdFavouriteProductDto)
        {
            var response = await _httpClient.GetAsync($"/api/UserFavouriteProducts?UserId={getByProductAndUserIdFavouriteProductDto.UserId}&ProductId={getByProductAndUserIdFavouriteProductDto.ProductId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetByProductAndUserIdUserFavouriteProductResponse>>().Result;
            return result;
        }

        public async Task<IRequestResult<List<GetByUserIdUserFavouriteProductResponse>>> GetByUserIdUserFavouriteProducts(int userId)
        {
            var response = await _httpClient.GetAsync($"/api/UserFavouriteProducts/GetByUserId?UserId={userId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<List<GetByUserIdUserFavouriteProductResponse>>>().Result;
            return result;
        }
    }
}
