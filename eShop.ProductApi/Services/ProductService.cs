
using AutoMapper;
using eShop.ProductApi.Models;
using eShop.ProductApi.Repositories;

namespace eShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task AddProductAsync(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.CreateAsync(productEntity);
        productDTO.Id = productEntity.Id;
    }

    public async Task UpdateProductAsync(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.UpdateAsync(productEntity);
        productDTO.Id = productEntity.Id;
    }

    public async Task DeleteProductAsync(int id)
    {
        var productEntity = _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteByIdAsync(productEntity.Id);
    }
}