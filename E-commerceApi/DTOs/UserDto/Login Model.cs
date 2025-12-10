using System;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class LoginModel
    {
        
        [EmailAddress(ErrorMessage ="Email is required")]
        public string Email { get; set; }=String.Empty;
        [Required (ErrorMessage ="password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }=String.Empty;
        public bool RememberMe {  get; set; }=false;
            
     
    }
}
