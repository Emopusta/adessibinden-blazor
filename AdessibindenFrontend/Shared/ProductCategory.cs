namespace AdessibindenFrontend.Shared;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
