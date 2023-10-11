using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace product_web_api.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Key is required")]
    [Range(1, 999)]
    public int Key { get; set; }

    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "VARCHAR(100)")]
    public string? Name { get; set; }

    public List<Product>? Products { get; set; }
}