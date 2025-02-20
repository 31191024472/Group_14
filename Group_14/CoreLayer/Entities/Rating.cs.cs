using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        [Column("rating_id")]
        public int RatingId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("movie_series_id")]
        public int MovieSeriesId { get; set; }

        [Column("rating")]
        public decimal Score { get; set; }
    }
}
