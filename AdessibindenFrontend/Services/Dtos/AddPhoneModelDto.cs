using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos;

public class AddPhoneModelDto : IDto
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; } = string.Empty;
}
