using System.ComponentModel.DataAnnotations;
using WebAPICSharpEVProject.Models;

namespace SCookie_ValidateSCookieIdFilterAttribute.Models
{
    public class SSookie_EnsureCorrectTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var SCookie = validationContext.ObjectInstance as SugarCookies;
            if (SCookie != null && !string.IsNullOrWhiteSpace(SCookie.CType))
            {
                if (SCookie.CType.Equals("Plain", StringComparison.OrdinalIgnoreCase) && SCookie.Size < 6)
                {
                    return new ValidationResult(" For plain cookies amount must be greater or equal to 6.");
                }
                else if (SCookie.CType.Equals("Decorated", StringComparison.OrdinalIgnoreCase) && SCookie.Size < 12)
                {
                    return new ValidationResult(" For Decorated cookies amount must  be greater or equal to 12.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

