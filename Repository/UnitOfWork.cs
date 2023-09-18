using Coursat.Data;
using Coursat.Models;
using Coursat.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Coursat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Courses = new MainRepository<Course>(_context);
            courseLessons = new MainRepository<CourseLessons>(_context);
           // MediaTypes = new MainRepository<MediaType>(_context);
            UserCourses = new MainRepository<UserCourse>(_context);
            Categories = new MainRepository<Category>(_context);
            Links = new MainRepository<UserLinks>(_context);

            IdentityRoles = new MainRepository<IdentityRole>(_context);
        }

        private readonly AppDbContext _context;
        public IRepository<Course> Courses{get; private set;}
        public IRepository<CourseLessons> courseLessons { get; private set; }

        //public IRepository<MediaType> MediaTypes { get; private set; }

        public IRepository<UserCourse> UserCourses { get; private set; }

        public IRepository<IdentityRole> IdentityRoles { get; private set; }

        public IRepository<Category> Categories { get;private set; }
        public IRepository<UserLinks> Links { get;private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }
    }
}
