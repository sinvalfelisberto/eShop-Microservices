using eShop.ProductApi.Context;
using eShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (product == null)
            throw new KeyNotFoundException($"Produto com ID {id} não encontrado!");
        return product;
    }

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteById(int id)
    {
        var product = await GetById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

}