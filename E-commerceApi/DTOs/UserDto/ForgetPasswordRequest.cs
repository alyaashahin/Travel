using System;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class ForgetPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }=String.Empty;
    }
}
