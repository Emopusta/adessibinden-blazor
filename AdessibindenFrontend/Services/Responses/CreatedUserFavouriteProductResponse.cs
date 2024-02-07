using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class CreatedUserFavouriteProductResponse : IResponse
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
}
