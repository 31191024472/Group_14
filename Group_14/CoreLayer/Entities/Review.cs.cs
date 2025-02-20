using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        [Column("review_id")]
        public int ReviewId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("movie_series_id")]
        public int MovieSeriesId { get; set; }

        [Column("review_text")]
        public string ReviewText { get; set; }

        [Column("review_date")]
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
