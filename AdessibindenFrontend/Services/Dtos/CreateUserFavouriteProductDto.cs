using Core.Application.Dtos;

namespace AdessibindenFrontend.Services.Dtos
{
    public class CreateUserFavouriteProductDto : IDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
