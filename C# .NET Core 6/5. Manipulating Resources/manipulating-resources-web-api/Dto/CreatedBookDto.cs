using System.ComponentModel.DataAnnotations;
using first_web_api.Validations;

namespace first_web_api.Dto;

public class CreatedBookDto
{
    [Required]
    [MaxLength(100), MinLength(1)]
    [CapitalLetter]
    public string? Title { get; set; }

    public DateTime? PublishedOn { get; set; }

    public List<int> AuthorIds { get; set; } = [];
}