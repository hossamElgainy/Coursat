using Coursat.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [DisplayName("Image")]
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? clientFile { get; set; }

        public virtual ICollection<CourseLessons>? CourseLessons { get; set; }
        public virtual ICollection<UserCourse>? UserCourse { get; set; }
        public string CreatedBy { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

    }
}
