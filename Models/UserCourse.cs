using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class UserCourse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [DisplayName("Regestration Date")]
        public DateTime RegestrationDate { get; set; }
    }
}
