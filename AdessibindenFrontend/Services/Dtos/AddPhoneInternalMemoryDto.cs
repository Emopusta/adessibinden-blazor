using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos;

public class AddPhoneInternalMemoryDto : IDto
{
    public int Id { get; set; }
    public string Capacity { get; set; }
}
