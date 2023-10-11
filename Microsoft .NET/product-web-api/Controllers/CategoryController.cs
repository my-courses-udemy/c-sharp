using Microsoft.AspNetCore.Mvc;
using product_web_api.DTO;
using product_web_api.services;

namespace product_web_api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<List<CategoryDto>> Get() => await _categoryService.Get();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        var category = await _categoryService.Get(id);
        if (category is null) return NotFound();
        return category;
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> Post(CategoryDto category)
    {
        var categorySaved = await _categoryService.Create(category);
        return CreatedAtAction(nameof(Get), new { id = category.Id }, categorySaved);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, CategoryDto categoryUpdated)
    {
        var isUpdated = await _categoryService.Update(id, categoryUpdated);
        if (isUpdated) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _categoryService.Remove(id);
        if (isDeleted) return NoContent();
        return NotFound();
    }
}