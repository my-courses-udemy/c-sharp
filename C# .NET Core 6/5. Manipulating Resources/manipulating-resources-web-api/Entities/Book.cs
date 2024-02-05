using System.ComponentModel.DataAnnotations;
using first_web_api.Validations;

namespace first_web_api.Entities;

public class Book
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100), MinLength(1)]
    [CapitalLetter]
    public string? Title { get; set; }

    public DateTime? PublishedOn { get; set; }

    public List<Comment> Comments { get; set; } = [];
    public List<AuthorBook> AuthorBooks { get; set; } = [];
}