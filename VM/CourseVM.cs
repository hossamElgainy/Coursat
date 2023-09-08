namespace Coursat.VM
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        public string CreatedBy { get; set; }
        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Category { get; set; }
    }
}
