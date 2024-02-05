using System.ComponentModel.DataAnnotations;

namespace first_web_api.Entities;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [MinLength(1), MaxLength(100)]
    public string? Content { get; set; }

    public int BookId { get; set; }

    public Book? Book { get; set; }
}