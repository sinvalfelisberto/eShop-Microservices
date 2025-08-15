
using AutoMapper;
using eShop.ProductApi.Models;
using eShop.ProductApi.Repositories;

namespace eShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
    {
        var categoriesEntity = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProductsAsync()
    {
        var categoriesEntity = await _categoryRepository.GetCategoryProductsAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task AddCategoryAsync(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.CreateAsync(categoryEntity);
        categoryDTO.CategoryId = categoryEntity.CategoryId;
    }

    public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.UpdateAsync(categoryEntity);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var categoryEntity =  _categoryRepository.GetByIdAsync(id).Result;
        await _categoryRepository.DeleteAsync(categoryEntity.CategoryId);
    }
}