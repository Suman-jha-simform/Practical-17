using System.ComponentModel.DataAnnotations;

namespace Practical_17.Models
{
    public class Roles
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; }

    }
}
