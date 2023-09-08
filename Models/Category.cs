using System.ComponentModel.DataAnnotations;

namespace Coursat.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }

    }
}
