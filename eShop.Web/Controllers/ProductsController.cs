using eShop.Web.Models;
using eShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductsService _productsService;
    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _productsService.GetAllProductsAsync();
        if (result == null)
            return NotFound("Error");

        return View(result);
    }

}