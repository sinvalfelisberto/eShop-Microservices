using System.Text;
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

    private const string PRODUCT_API_NAME = "ProductAPI";

    public ProductsService(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _apiEndpoint = config["ServiceUri:ProductAPI"]; 
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
    {
        var client = _httpClientFactory.CreateClient(PRODUCT_API_NAME);
        using var response = await client.GetAsync(_apiEndpoint);
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _productsViewModel = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(apiResponse, _options);
        }
        else
        {
            _productsViewModel = Enumerable.Empty<ProductViewModel>();
        }

        return _productsViewModel;
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient(PRODUCT_API_NAME);
        using var response = await client.GetAsync(_apiEndpoint + id);
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _productViewModel = JsonSerializer.Deserialize<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            _productViewModel = null;
        }
        return _productViewModel;
    }

    public async Task<ProductViewModel> CreateProductAsync(ProductViewModel productVM)
    {
        var client = _httpClientFactory.CreateClient(PRODUCT_API_NAME);
        StringContent content = new StringContent(JsonSerializer.Serialize(productVM), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync(_apiEndpoint, content);
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _productViewModel = JsonSerializer.Deserialize<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            _productViewModel = null;
        }
        return _productViewModel;
    }

    public async Task<ProductViewModel> UpdateProductAsync(ProductViewModel productVM)
    {
        var client = _httpClientFactory.CreateClient(PRODUCT_API_NAME);
        ProductViewModel productUpdated = new ProductViewModel();

        using var response = await client.PutAsJsonAsync(_apiEndpoint, productVM);
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            productUpdated = JsonSerializer.Deserialize<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            productUpdated = null;
        }
        return productUpdated;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var client = _httpClientFactory.CreateClient(PRODUCT_API_NAME);

        using var response = await client.DeleteAsync(_apiEndpoint + id);
        if (response.IsSuccessStatusCode)
            return true;

        return false;
    }
}
