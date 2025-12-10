using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models
{
    public class SearchHistory
    {
        [Key]
        [Column("search_id")]
        public int SearchId { get; set; }

        [Required]
        [Column("user_id")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Column("query_text")]
        [MaxLength(500)]
        public string QueryText { get; set; } = string.Empty;

        [Column("search_date")]
        public DateTime SearchDate { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
