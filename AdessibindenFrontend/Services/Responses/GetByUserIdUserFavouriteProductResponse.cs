using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class GetByUserIdUserFavouriteProductResponse : IResponse
{
    public int ProductId { get; set; }
    public string ProductTitle { get; set; }

}
