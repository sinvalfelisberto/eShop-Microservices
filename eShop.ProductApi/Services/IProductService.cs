namespace eShop.ProductApi.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductDTO ProductDTO);
    Task UpdateProductAsync(ProductDTO ProductDTO);
    Task DeleteProductAsync(int id);
}