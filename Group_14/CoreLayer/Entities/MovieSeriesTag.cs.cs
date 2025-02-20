using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    [Table("MovieSeriesTags")]
    public class MovieSeriesTag
    {
        [Key]
        [Column("movie_series_id")]
        public int MovieSeriesId { get; set; }

        [Key]
        [Column("tag_id")]
        public int TagId { get; set; }
    }
}
