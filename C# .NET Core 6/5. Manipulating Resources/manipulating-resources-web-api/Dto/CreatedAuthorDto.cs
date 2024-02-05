using System.ComponentModel.DataAnnotations;
using first_web_api.Validations;

namespace first_web_api.Dto;

public class CreatedAuthorDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100, ErrorMessage = "The field {0} must not be greater than {1} characters"),
     MinLength(2, ErrorMessage = "The field {0} must not be less than {1} characters")]
    [CapitalLetter]

    public string? Name { get; set; }
}