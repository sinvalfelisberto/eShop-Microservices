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
        mb.Entity<Product>().HasKey(c => c.Id);
        mb.Entity<Product>().Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        mb.Entity<Product>().Property(c => c.Description)
            .HasMaxLength(250)
            .IsRequired();

        mb.Entity<Product>()
            .Property(c => c.Price)
            .HasPrecision(15, 2);

        mb.Entity<Category>()
            .HasMany(p => p.Products)
            .WithOne(c => c.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Category>()
            .HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios",
                }
            );
    }
}