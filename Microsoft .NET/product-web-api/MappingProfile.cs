using AutoMapper;
using product_web_api.DTO;
using product_web_api.Models;

namespace product_web_api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}