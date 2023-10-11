using System.ComponentModel.DataAnnotations;

namespace product_web_api.DTO;

public class CategoryDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Key is required")]
    [Range(1, 999)]
    public int Key { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
}