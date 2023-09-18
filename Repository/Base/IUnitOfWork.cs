using Coursat.Models;
using Microsoft.AspNetCore.Identity;

namespace Coursat.Repository.Base
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Course> Courses { get; }
        IRepository<IdentityRole> IdentityRoles { get; }
        IRepository<CourseLessons> courseLessons { get; }
        //IRepository<MediaType> MediaTypes { get; }
        IRepository<UserCourse> UserCourses { get; }
        IRepository<Category> Categories { get; }
        IRepository<UserLinks> Links { get; }

        int CommitChanges();
    }
}
