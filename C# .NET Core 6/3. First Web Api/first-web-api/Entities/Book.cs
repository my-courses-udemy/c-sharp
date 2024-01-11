using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace first_web_api.Entities;

public class Book
{
    public int Id { get; set; }

    [MaxLength(100), MinLength(1)] public string? Title { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }
}