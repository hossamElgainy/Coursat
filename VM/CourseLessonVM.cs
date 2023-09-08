

namespace Coursat.VM
{
    public class CourseLessonVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeItemAdded { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int MediaTypeId { get; set; }
    }
}
