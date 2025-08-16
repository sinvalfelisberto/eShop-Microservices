namespace eShop.ProductApi;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using eShop.ProductApi.Models;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Description is required!")]
    [MinLength(5)]
    [MaxLength(250)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The Price is required!")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is required!")]
    [Range(0, 9999)]
    public long Stock { get; set; }
    public string? ImageURL { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}