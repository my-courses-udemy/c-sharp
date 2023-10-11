using System.ComponentModel.DataAnnotations;

namespace product_web_api.DTO;

public class ProductDto
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "CategoryId is required")]
    public int CategoryId { get; set; }
}