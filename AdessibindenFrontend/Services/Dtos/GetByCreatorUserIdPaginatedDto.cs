using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Dtos
{
    public class GetByCreatorUserIdPaginatedDto : IResponse
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
    }
}
