using eShop.Web.Models;

namespace eShop.Web.Services;

public interface IProductsService
{
    Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
    Task<ProductViewModel> GetProductByIdAsync(int id);
    Task<ProductViewModel> CreateProductAsync(ProductViewModel productVM);
    Task<ProductViewModel> UpdateProductAsync(ProductViewModel productVM);
    Task<bool> DeleteProductAsync(int id);
}
