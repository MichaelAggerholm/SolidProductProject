using System.ComponentModel.DataAnnotations;

namespace SolidProductApi.Models
{
    public class Electronic : Product
    {
        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Features { get; set; } = string.Empty;
    }
}
