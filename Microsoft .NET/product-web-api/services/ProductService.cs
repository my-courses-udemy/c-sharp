using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_web_api.DTO;
using product_web_api.Models;

namespace product_web_api.services;

public class ProductService: IProductService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Get()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products
            .Select(product => _mapper.Map<ProductDto>(product))
            .ToList();
    }

    public async Task<List<ProductDto>> GetByCategory(int categoryId)
    {
        var products = await _dbContext.Products
            .Where(product => product.CategoryId == categoryId)
            .ToListAsync();
        return products
            .Select(product => _mapper.Map<ProductDto>(product))
            .ToList();
    }

    public async Task<ProductDto?> Get(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Create(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var productSaved = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ProductDto>(productSaved.Entity);
    }
}