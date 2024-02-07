using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos;

public class PaginatedProductDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
