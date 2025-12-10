using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class SetActiveUser
    {
        [Required] public string Email { get; set; } = string.Empty;
        [Required] public bool IsActive { get; set; }

    }
}
