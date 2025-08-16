using eShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAsync()
    {
        var categoriesDto = await _categoryService.GetAllCategoriesAsync();
        if (categoriesDto is null)
            return NotFound("Categories not found!");
        return Ok(categoriesDto);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProductsAsync()
    {
        var categoriesDto = await _categoryService.GetCategoriesProductsAsync();
        if (categoriesDto is null)
            return NotFound("Categories not found!");
        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryByIdAsynd(int id)
    {
        var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
        if (categoryDto is null)
            return NotFound("Category not found!");
        return Ok(categoryDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategoryAsync([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Invalid Data!");

        await _categoryService.AddCategoryAsync(categoryDTO);
        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId)
            return BadRequest();

        if (categoryDTO is null)
            return BadRequest();

        await _categoryService.UpdateCategoryAsync(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCategoryAsync(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryByIdAsync(id);
        if (categoryDTO is null)
            return NotFound("Category not found!");

        await _categoryService.DeleteCategoryAsync(categoryDTO.CategoryId);
        return Ok(categoryDTO); 
    }
}