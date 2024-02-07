using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos;

public class GetByBrandIdPhoneModelDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
