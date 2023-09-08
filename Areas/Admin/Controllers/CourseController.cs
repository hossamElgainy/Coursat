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
using Microsoft.AspNetCore.Identity;

namespace Coursat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        // GET: Admin/Category
        public IActionResult Index()
        {
            return _unitOfWork.Courses != null ? 
                          View( _unitOfWork.Courses.GetAll()) :
                          Problem("Entity set 'AppDbContext.Category'  is null.");
        }

        // GET: Admin/Category/Details/5
        public IActionResult Details(int id)
        {
            if (_unitOfWork.Courses == null)
            {
                return NotFound();
            }

            var category =  _unitOfWork.Courses.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            var AllCat = _unitOfWork.Categories.GetAll();

            SelectList category = new SelectList(AllCat, "Id", "Name", 0);
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
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

            var course = _unitOfWork.Courses.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            var AllCat = _unitOfWork.Categories.GetAll();

            SelectList category = new SelectList(AllCat, "Id", "Name", 0);
            ViewBag.Category = category;
            return View(course);
        }

        // POST: Admin/Category/Edit/5
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
                    course.clientFile.CopyTo(new FileStream(fullPath, FileMode.Append));
                    course.ImagePath = fileName;
                }
                _unitOfWork.Courses.Update(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Admin/Category/Delete/5
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

        // POST: Admin/Categories/Delete/5
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
