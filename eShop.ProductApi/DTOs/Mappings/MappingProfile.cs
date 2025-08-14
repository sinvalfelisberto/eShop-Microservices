using eShop.ProductApi.Models;
using AutoMapper;

namespace eShop.ProductApi.DTO.Mappings;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }    

}