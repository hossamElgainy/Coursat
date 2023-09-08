using Coursat.Data;
using Coursat.Models;
using Coursat.Repository.Base;
using Coursat.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace Coursat.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public CoursesController(IUnitOfWork unitOfWork,AppDbContext context ,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager; 
        }
        public IActionResult Index()
        {
            var course = (from courses in _unitOfWork.Courses.GetAll()
                         join user in _context.Users.ToList()
                         on courses.CreatedBy equals user.Id  

                          select new CourseVM
                         {
                             Id = courses.Id,
                             Title = courses.Title,
                             Description = courses.Description,
                             ImagePath = courses.ImagePath,
                             CreatedAt = courses.CreatedAt,
                             CreatedBy = $"{user.FirstName} {user.LastName}", 
                             UserId = user.Id,
                          }).ToList();

            return View(course);
        }

        public IActionResult Info(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return NotFound();
            }
       
            var course = _unitOfWork.Courses.FindOne(id,"CourseLessons").FirstOrDefault(z=>z.Id==id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            ViewBag.HasSubscription = _unitOfWork.UserCourses.SelectOne(z=>z.UserId== _userManager.GetUserId(HttpContext.User) &&
                                                                        z.CourseId==id);
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(UserCourse userCourse)
        {
            userCourse.RegestrationDate = DateTime.Now;
            if(ModelState.IsValid)
            {
                _unitOfWork.UserCourses.Add(userCourse);
                return RedirectToAction(nameof(Info));
            }

            return View(userCourse);
        }
        public IActionResult CatCourses(int id)
        {
            var course = (from courses in _unitOfWork.Courses.GetAll()
                          join user in _context.Users.ToList()
                          on courses.CreatedBy equals user.Id
                          join cat in _unitOfWork.Categories.GetAll()
                          on courses.CategoryId equals cat.Id
                          where cat.Id == id
                          select new Course
                          {
                              Id = courses.Id,
                              Title = courses.Title,
                              Description = courses.Description,
                              ImagePath = courses.ImagePath,
                              CreatedAt = courses.CreatedAt,
                              CreatedBy = user.FirstName + " " + user.LastName, 
                          }).ToList();
            ViewBag.CategoryName = _unitOfWork.Categories.GetById(id).Name;
            return View(course);
        }
        [Authorize(Roles ="Student")]

        public ActionResult MyLearning()
        {
            var MyLearning = (from userCourses in _unitOfWork.UserCourses.GetAll()
                              join courses in _unitOfWork.Courses.GetAll()
                              on userCourses.UserId equals _userManager.GetUserId(User)
                              where userCourses.CourseId == courses.Id

                              select new Course
                              {
                                  Id = courses.Id,
                                  Title = courses.Title,
                                  Description = courses.Description,
                                  Price = courses.Price,
                                  CreatedAt = courses.CreatedAt,
                                  ImagePath = courses.ImagePath,
                              }).ToList();
            return View(MyLearning);
        }
    }
}