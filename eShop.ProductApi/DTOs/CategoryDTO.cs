using System.ComponentModel.DataAnnotations;
using eShop.ProductApi.Models;

namespace eShop.ProductApi;

public class CategoryDTO
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}