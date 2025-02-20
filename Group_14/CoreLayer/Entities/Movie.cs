using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Group_14.MovieReview.CoreLayer.Entities
{
    [Table("MoviesSeries")]
    public class Movie
    {
        [Key]
        [Column("movie_series_id")] // Đổi tên để khớp với database
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("release_date")] // Đổi tên để khớp với database
        public DateTime ReleaseDate { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
