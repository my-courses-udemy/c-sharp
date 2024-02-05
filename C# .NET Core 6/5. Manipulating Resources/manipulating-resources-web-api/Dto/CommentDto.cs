using System.ComponentModel.DataAnnotations;

namespace first_web_api.Dto;

public class CommentDto
{
    public int Id { get; set; }

    [Required]
    [MinLength(1), MaxLength(100)]
    public string? Content { get; set; }

    public int BookId { get; set; }
}