using eShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _produtcService;

    public ProductsController(IProductService productService)
    {
        _produtcService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAsync()
    {
        var productDTO = await _produtcService.GetAllProductsAsync();
        if (productDTO is null)
            return NotFound("Products not found!");
        return Ok(productDTO);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByIdAsynd(int id)
    {
        var productDTO = await _produtcService.GetProductByIdAsync(id);
        if (productDTO is null)
            return NotFound("Product not found!");
        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProductAsync([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Invalid Data!");

        await _produtcService.AddProductAsync(productDTO);
        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProductAsync(int id, [FromBody] ProductDTO productDTO)
    {
        if (id != productDTO.Id)
            return BadRequest();

        if (productDTO is null)
            return BadRequest();

        await _produtcService.UpdateProductAsync(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProductAsync(int id)
    {
        var productDTO = await _produtcService.GetProductByIdAsync(id);
        if (productDTO is null)
            return NotFound("Product not found!");

        await _produtcService.DeleteProductAsync(productDTO.Id);
        return Ok(productDTO);
    }

}