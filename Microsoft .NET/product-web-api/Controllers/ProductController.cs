using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_web_api.DTO;
using product_web_api.services;

namespace product_web_api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]s")]
public class ProductController : ControllerBase
{
    private IProductService _productService;

    public ProductController(IProductService productService) =>
        _productService = productService;

    [HttpGet]
    public async Task<List<ProductDto>> Get() =>
        await _productService.Get();

    [HttpGet]
    [Route("category/{categoryId:int}")]
    public async Task<List<ProductDto>> GetByCategories(int categoryId) =>
        await _productService.GetByCategory(categoryId);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var product = await _productService.Get(id);
        if (product is null) return NotFound();
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Post(ProductDto product)
    {
        var productSaved = await _productService.Create(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, productSaved);
    }
}