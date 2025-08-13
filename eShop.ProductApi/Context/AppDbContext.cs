using Microsoft.EntityFrameworkCore;
using eShop.ProductApi.Models;

namespace eShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        //category
        mb.Entity<Category>().HasKey(c => c.CategoryId);

        mb.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        //product
        
    }
}