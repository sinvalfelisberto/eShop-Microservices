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

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoryProducts()
    {
        return await _context.Categories.Include(p => p.Products).ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        if (category == null)
            throw new KeyNotFoundException($"Categoria com CategoryId {id} não encontrada!");
        
        return category;
    }

    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
