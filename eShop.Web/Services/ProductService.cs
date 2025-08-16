using System.Text.Json;
using eShop.Web.Models;

namespace eShop.Web.Services.Contracts;

public class ProductsService : IProductsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiEndpoint;
    private readonly JsonSerializerOptions _options;
    private ProductViewModel _productViewModel;
    private IEnumerable<ProductViewModel> _productsViewModel;

    public ProductsService(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _apiEndpoint = config["ServiceUri:ProductAPI"];
        _options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
    }

    public Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> CreateProductAsync(ProductViewModel productVM)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> UpdateProductAsync(ProductViewModel productVM)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }
}
