using eShop.ProductApi.Context;
using eShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoryProductsAsync()
    {
        return await _context.Categories.Include(p => p.Products).ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();        
        return category;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;

    }
}
