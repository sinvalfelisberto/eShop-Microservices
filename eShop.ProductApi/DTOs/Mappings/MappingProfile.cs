using eShop.ProductApi.Models;
using AutoMapper;

namespace eShop.ProductApi.DTO.Mappings;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>()
            .ForMember(x => x.CategoryName, opt => opt
                        .MapFrom(src => src.Category.Name));
        CreateMap<ProductDTO, Product>();
        CreateMap<CategoryDTO, Category>();
        
    }   

}