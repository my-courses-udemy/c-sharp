using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace first_web_api.Entities;

public class Author
{
    public int Id { get; set; }

    [MaxLength(100), MinLength(1)] public string? Name { get; set; }

    public required List<Book>? Books { get; set; }
}