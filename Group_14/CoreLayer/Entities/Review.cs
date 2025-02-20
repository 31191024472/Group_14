using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Group_14.CoreLayer.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        public string ReviewText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("MovieId")]
        public MovieSeries Movie { get; set; }
    }
}
