using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;
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
            var response = await _httpClient.DeleteFromJsonAsync<RequestResult<DeletedUserFavouriteProductResponse>>($"/api/UserFavouriteProducts/UserId={deleteUserFavouriteProductDto.UserId}&ProductId={deleteUserFavouriteProductDto.ProductId}");
            return response;
        }

        public async Task<IRequestResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetCurrentFavouriteByUserIdAndProducId(GetByProductAndUserIdFavouriteProductDto getByProductAndUserIdFavouriteProductDto)
        {
            var response = await _httpClient.GetAsync($"/api/UserFavouriteProducts?UserId={getByProductAndUserIdFavouriteProductDto.UserId}&ProductId={getByProductAndUserIdFavouriteProductDto.ProductId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetByProductAndUserIdUserFavouriteProductResponse>>().Result;
            return result;
        }
    }
}
