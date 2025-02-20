using System.ComponentModel.DataAnnotations;

namespace Group_14.CoreLayer.Entities
{
    public class MovieSeries
    {
        [Key]
        public int MovieId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Description { get; set; }
    }
}
