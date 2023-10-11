using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_web_api.DTO;
using product_web_api.Models;

namespace product_web_api.services;

public class CategoryService : ICategoryService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Get()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return categories
            .Select(category => _mapper.Map<CategoryDto>(category))
            .ToList();
    }

    public async Task<CategoryDto?> Get(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> Create(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var categorySaved = await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(categorySaved.Entity);
    }

    public async Task<bool> Update(int id, CategoryDto categoryDto)
    {
        var categoryUpdated = _mapper.Map<Category>(categoryDto);
        var category = await _dbContext.Categories.FindAsync(id);
        if (category is null) return false;
        categoryUpdated.Id = category.Id;
        _dbContext.Entry(category).CurrentValues.SetValues(categoryUpdated);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category is null) return false;
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}