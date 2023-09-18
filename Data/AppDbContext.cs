using Coursat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(200,MinimumLength =2)]
        public string? FirstName { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string? LastName { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string? Address1 { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string? Address2 { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? PsotCode { get; set; }
        [ForeignKey("UserId")]
        public ICollection<UserCourse> UserCourse { get; set; }

        [ForeignKey("CreatedBy")]
        public ICollection<Course> InstructorCourses { get; set; }
        
    }
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<CourseLessons> CourseLessons { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserLinks> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }, 
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Instructor",
                    NormalizedName = "instructor",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Student",
                    NormalizedName = "student",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            base.OnModelCreating(builder);
        }
    }
}
