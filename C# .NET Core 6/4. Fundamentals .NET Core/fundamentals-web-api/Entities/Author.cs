using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using first_web_api.Validations;

namespace first_web_api.Entities;

public class Author
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100, ErrorMessage = "The field {0} must not be greater than {1} characters"),
     MinLength(2, ErrorMessage = "The field {0} must not be less than {1} characters")]
    [CapitalLetter]
    public string? Name { get; set; }

    [Range(18, 120)] [NotMapped] public int Age { get; set; }

    [CreditCard] [NotMapped] public string? CreditCard { get; set; }

    [Url] [NotMapped] public string? Url { get; set; }

    public required List<Book>? Books { get; set; }
}