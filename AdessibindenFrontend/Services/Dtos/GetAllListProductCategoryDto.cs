using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos
{
    public class GetAllListProductCategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
