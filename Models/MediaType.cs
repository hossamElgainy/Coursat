using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [DisplayName("Image")]
        public string ThumbnailImagePath { get; set; }
        public virtual ICollection<CourseLessons>? CourseLessons { get; set; }
    }
}
