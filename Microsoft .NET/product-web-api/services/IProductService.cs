using product_web_api.DTO;

namespace product_web_api.services;

public interface IProductService
{
    Task<List<ProductDto>> Get();

    Task<List<ProductDto>> GetByCategory(int categoryId);

    Task<ProductDto?> Get(int id);

    Task<ProductDto> Create(ProductDto productDto);
}