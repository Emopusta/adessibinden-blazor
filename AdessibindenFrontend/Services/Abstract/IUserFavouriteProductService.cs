using AdessibindenFrontend.Core.Application.Responses;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract;

public interface IUserFavouriteProductService
{
    public Task<IRequestResult<CreatedUserFavouriteProductResponse>> AddFavourites(CreateUserFavouriteProductDto createUserFavouriteProductDto);
    public Task<IRequestResult<DeletedUserFavouriteProductResponse>> DeleteFavourites(DeleteUserFavouriteProductDto deleteUserFavouriteProductDto);
    public Task<IRequestResult<GetByProductAndUserIdUserFavouriteProductResponse>> GetCurrentFavouriteByUserIdAndProductId(GetByProductAndUserIdFavouriteProductDto getByProductAndUserIdFavouriteProductDto);
    public Task<IRequestResult<ListResponse<GetByUserIdUserFavouriteProductResponse>>> GetByUserIdUserFavouriteProducts(int userId);
}