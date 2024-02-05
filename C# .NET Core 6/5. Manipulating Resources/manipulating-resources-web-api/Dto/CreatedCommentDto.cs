using System.ComponentModel.DataAnnotations;

namespace first_web_api.Dto;

public class CreatedCommentDto
{
    [Required]
    [MinLength(1), MaxLength(100)]
    public string? Content { get; set; }
}