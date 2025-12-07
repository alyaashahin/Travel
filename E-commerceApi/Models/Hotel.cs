using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceApi.Models
{
    public class Hotel
    {
        [Key]
        [Column("hotel_id")]
        public int HotelId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Column("address")]
        [MaxLength(500)]
        public string? Address { get; set; }

        //[Column("city")]
        //[MaxLength(100)]
        //public string? City { get; set; }

        //[Column("state")]
        //[MaxLength(100)]
        //public string? State { get; set; }

        //[Required]
        //[Column("country")]
        //[MaxLength(100)]
        //public string Country { get; set; } = string.Empty;

        [Column("zip_code")]
        [MaxLength(20)]
        public string? ZipCode { get; set; }

        [Column("description")]
        [MaxLength(2000)]
        public string? Description { get; set; }

        [Column("star_rating")]
        public decimal? StarRating { get; set; }

        [Column("amenities", TypeName = "nvarchar(max)")]
        public string? Amenities { get; set; } // JSON string for amenities like Wi-Fi, pool, AC

       //[Column("image_gallery", TypeName = "nvarchar(max)")]
        public List<string> ImageGallery { get; set; } = new List<string>();

        // Foreign Key
        [Column("city_id")]
        public int? CityId { get; set; }

        // Navigation properties
        [ForeignKey("CityId")]
        public virtual City? CityNavigation { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
