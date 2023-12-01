using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coursat.Data;
using Coursat.Models;
using Coursat.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;

namespace Coursat.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    [Authorize(Roles = "Instructor")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _host;
        private readonly UserManager<ApplicationUser> _userManager;


        public CourseController(IUnitOfWork unitOfWork,IHostingEnvironment host, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _host = host;
            _userManager = userManager;
        }
        // GET: Instructor/Category
        public IActionResult Index()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var InstractorCourses = _unitOfWork.Courses.GetGroupedList(z => z.CreatedBy == userid);
            return InstractorCourses != null ? 
                          View(InstractorCourses) :
                          Problem("Entity set 'AppDbContext.Category'  is null.");
        }

        // GET: Instructor/Course/Info/5
        public IActionResult Info(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return NotFound();
            }
            var course = _unitOfWork.Courses.FindOne(id, new string[] { "CourseLessons" } ).FirstOrDefault(z => z.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            return View(course);
        }

        public IActionResult Create()
        {
            var AllCat = _unitOfWork.Categories.GetAll();

            SelectList category = new SelectList(AllCat, "Id", "Name", 0);
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            string fileName = string.Empty;

            var userid = _userManager.GetUserId(HttpContext.User);
            course.CreatedBy = userid;
            course.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                 if (course.clientFile != null)
                 {
                     string myUpload = Path.Combine(_host.WebRootPath, "CategoryImages");
                     fileName = course.clientFile.FileName;
                     string fullPath = Path.Combine(myUpload, fileName);
                    course.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    course.ImagePath = fileName;
                 }
                _unitOfWork.Courses.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Admin/Categories/Edit/5
        public IActionResult Edit(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return NotFound();
            }

            var Course = _unitOfWork.Courses.GetById(id);
            if (Course == null)
            {
                return NotFound();
            }
            var AllCat = _unitOfWork.Categories.GetAll();

            SelectList category = new SelectList(AllCat, "Id", "Name", 0);
            ViewBag.Category = category;
            return View(Course);
        }

        // POST: Instructor/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }
            string fileName = string.Empty;


            if (ModelState.IsValid)
            {
                if (course.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "CategoryImages");
                    fileName = course.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    course.clientFile.CopyTo(new FileStream(fullPath, FileMode.Append));
                    course.ImagePath = fileName;
                }
                _unitOfWork.Courses.Update(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Instructor/Category/Delete/5
        public IActionResult Delete(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return NotFound();
            }

            var course = _unitOfWork.Courses.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Instructor/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return Problem("Entity set 'AppDbContext.Categories'  is null.");
            }
            var course = _unitOfWork.Courses.GetById(id);
            if (course != null)
            {
                _unitOfWork.Courses.Delete(course);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _unitOfWork.Courses.GetById(id) !=null ?true:false;
        }
    }
}
