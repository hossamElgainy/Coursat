using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class CourseLessons
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Creation Date")]
        public DateTime DateTimeItemAdded { get; set; }
        public string Content { get; set; }
        [NotMapped]
        public IFormFile clientFile { get; set; }
        [ForeignKey("Course")]

        public int CourseId { get; set; }
        
    }
}
