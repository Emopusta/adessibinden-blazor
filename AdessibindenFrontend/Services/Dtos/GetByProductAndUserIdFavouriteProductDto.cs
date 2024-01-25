using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos
{
    public class GetByProductAndUserIdFavouriteProductDto : IDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
