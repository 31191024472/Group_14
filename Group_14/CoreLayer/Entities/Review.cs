namespace Group_14.MovieReview.CoreLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
