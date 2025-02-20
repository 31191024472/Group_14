using System.ComponentModel.DataAnnotations;

namespace Group_14.CoreLayer.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required, MaxLength(100)]
        public string TagName { get; set; }
    }
}
