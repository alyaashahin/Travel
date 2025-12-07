using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceApi.Models
{
    public class Favorite
    {
        [Key]
        [Column("favorite_id")]
        public int FavoriteId { get; set; }

        [Required]
        [Column("user_id")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Column("hotel_id")]
        public int HotelId { get; set; }

        [Column("added_date")]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
