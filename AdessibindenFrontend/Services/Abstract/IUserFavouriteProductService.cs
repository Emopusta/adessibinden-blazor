using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;
using Application.Features.UserFavouriteProducts.Queries.GetByUserId;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IUserFavouriteProductService
    {
        public Task<IRequestResult<CreatedUserFavouriteProductResponse>> AddFavourites(CreateUserFavouriteProductDto createUserFavouriteProductDto);
        public Task<IRequestResult<DeletedUserFavouriteProductResponse>> DeleteFavourites(DeleteUserFavouriteProductDto deleteUserFavouriteProductDto);
        public Task<IRequestResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetCurrentFavouriteByUserIdAndProductId(GetByProductAndUserIdFavouriteProductDto getByProductAndUserIdFavouriteProductDto);
        public Task<IRequestResult<List<GetByUserIdUserFavouriteProductResponse>>> GetByUserIdUserFavouriteProducts(int userId);

    }
}
