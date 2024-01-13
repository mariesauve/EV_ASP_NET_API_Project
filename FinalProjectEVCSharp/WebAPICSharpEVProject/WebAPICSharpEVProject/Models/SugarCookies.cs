
using SCookie_ValidateSCookieIdFilterAttribute.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPICSharpEVProject.Models
{
    public class SugarCookies
    {
        public SugarCookies() { }

        public int Id { get; set; }
        [Required]
        public string? Flavour { get; set; }
        
        public string? CType { get; set; }
        [SSookie_EnsureCorrectType]
        public int? Size { get; set; }
        [Required]

        public float? Price { get; set; }
       


    }
}
