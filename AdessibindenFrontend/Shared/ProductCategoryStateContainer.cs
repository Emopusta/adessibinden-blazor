namespace AdessibindenFrontend.Shared;

public class ProductCategoryStateContainer
{
    public ProductCategory ProductCategory { get; set; } = new();

    public event Action? OnStateChange;
    public void SetValue(ProductCategoryDto productCategoryDto)
    {
        ProductCategory.Id = productCategoryDto.Id;
        ProductCategory.Name = productCategoryDto.Name;
        OnStateChange?.Invoke();
    }
}
