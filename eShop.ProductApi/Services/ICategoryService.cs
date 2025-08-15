namespace eShop.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProductsAsync();
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(CategoryDTO categoryDTO);
    Task UpdateCategoryAsync(CategoryDTO categoryDTO);
    Task DeleteCategoryAsync(int id);
}