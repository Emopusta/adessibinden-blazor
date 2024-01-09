using Core.Application.Dtos;

namespace AdessibindenFrontend.Services.Dtos
{
    public class AddPhoneProductDto : IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
