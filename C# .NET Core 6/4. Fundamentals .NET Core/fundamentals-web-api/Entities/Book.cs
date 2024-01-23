using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first_web_api.Entities;

public class Book : IValidatableObject
{
    public int Id { get; set; }

    [MaxLength(100), MinLength(1)] public string? Title { get; set; }

    [NotMapped] public string? Description { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(Title)) yield break;
        var firstLetter = Title?[0].ToString();
        if (firstLetter != firstLetter?.ToUpper())
        {
            yield return new ValidationResult("The first letter of the title " +
                                              "must be uppercase",
                new[] { nameof(Title) });
        }

        if (Description?.Length < 100 && Description?.Length > 5)
        {
            yield return new ValidationResult("The description must not be greater " +
                                              "than 100 characters",
                new[] { nameof(Description) });
        }
    }
}