using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class UpdateUser
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
