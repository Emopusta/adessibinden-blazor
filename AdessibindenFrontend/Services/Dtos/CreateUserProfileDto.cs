
using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos;

public class CreateUserProfileDto : IDto
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }

    public CreateUserProfileDto() { }
}
