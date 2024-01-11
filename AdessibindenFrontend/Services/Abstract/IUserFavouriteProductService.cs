using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.UserFavouriteProducts.Commands.Create;
using Application.Features.UserFavouriteProducts.Commands.Delete;
using Application.Features.UserFavouriteProducts.Queries.GetByProductAndUserId;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IUserFavouriteProductService
    {
        public Task<IRequestResult<CreatedUserFavouriteProductResponse>> AddFavourites(CreateUserFavouriteProductDto createUserFavouriteProductDto);
        public Task<IRequestResult<DeletedUserFavouriteProductResponse>> DeleteFavourites(DeleteUserFavouriteProductDto deleteUserFavouriteProductDto);
        public Task<IRequestResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetCurrentFavouriteByUserIdAndProducId(GetByProductAndUserIdFavouriteProductDto getByProductAndUserIdFavouriteProductDto);

    }
}
