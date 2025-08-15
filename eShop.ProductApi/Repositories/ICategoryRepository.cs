using eShop.ProductApi.Models;

namespace eShop.ProductApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetCategoryProductsAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<Category> DeleteAsync(int id);

}