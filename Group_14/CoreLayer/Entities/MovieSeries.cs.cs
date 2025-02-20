using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    [Table("MoviesSeries")]
    public class MovieSeries
    {
        [Key]
        [Column("movie_series_id")]
        public int MovieSeriesId { get; set; }

        [Required, MaxLength(100)]
        [Column("title")]
        public string Title { get; set; }

        [MaxLength(50)]
        [Column("genre")]
        public string Genre { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
