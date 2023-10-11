using product_web_api.DTO;

namespace product_web_api.services;

public interface ICategoryService
{
    Task<List<CategoryDto>> Get();
    Task<CategoryDto?> Get(int id);
    Task<CategoryDto> Create(CategoryDto category);
    Task<bool> Update(int id, CategoryDto categoryUpdated);
    Task<bool> Remove(int id);
}