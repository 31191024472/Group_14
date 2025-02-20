using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    public class MovieTag
    {
        public int MovieId { get; set; }
        public int TagId { get; set; }

        [ForeignKey("MovieId")]
        public MovieSeries Movie { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
