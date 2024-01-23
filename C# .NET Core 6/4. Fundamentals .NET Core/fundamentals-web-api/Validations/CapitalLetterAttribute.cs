using System.ComponentModel.DataAnnotations;

namespace first_web_api.Validations;

public class CapitalLetterAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var firstLetter = value.ToString()?[0].ToString();
        return firstLetter != firstLetter?.ToUpper()
            ? new ValidationResult("The first letter must be capital")
            : ValidationResult.Success;
    }
}