using Microsoft.AspNetCore.Identity;

namespace Travel.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        // Navigation properties
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();
    }
}
