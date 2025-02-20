using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_14.CoreLayer.Entities
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Column("tag_id")]
        public int TagId { get; set; }

        [Required, MaxLength(50)]
        [Column("tag_name")]
        public string TagName { get; set; }
    }
}
