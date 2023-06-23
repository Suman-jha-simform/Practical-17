using System.ComponentModel.DataAnnotations;

namespace Practical_17.Models
{
    public class UserLogin
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
