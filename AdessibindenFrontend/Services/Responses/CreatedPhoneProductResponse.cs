using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class CreatedPhoneProductResponse : IResponse
{
    public int ProductCategoryId { get; set; }
    public int CreatorUserId { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public int InternalMemoryId { get; set; }
    public int RAMId { get; set; }
    public bool UsageStatus { get; set; }
    public decimal Price { get; set; }
}
