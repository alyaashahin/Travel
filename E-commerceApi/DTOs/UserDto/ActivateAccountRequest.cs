namespace Travel.Models
{
    public class ActivateAccountRequest
    {
        public string Email { get; set; }=string.Empty;
        public string activationcode { get; set; }=string.Empty;
    }
}
