using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceApi.Models
{
    public class City
    {
        [Key]
        [Column("city_id")]
        public int CityId { get; set; }

        [Required]
        [Column("city_name")]
        [MaxLength(100)]
        public string CityName { get; set; } = string.Empty;

        [Column("photo")]
        [MaxLength(500)]
        public string? Photo { get; set; }

        // Navigation property
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
