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
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Coursat.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    [Authorize(Roles = "Instructor")]

    public class CourseLessonsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _host;

        public CourseLessonsController(IUnitOfWork unitOfWork, IHostingEnvironment host)
        {
            _unitOfWork = unitOfWork;
            _host = host;
        }

        // GET: Instructor/courseLessons
        public IActionResult Index(int CourseId)
        {
            var Lessons = _unitOfWork.courseLessons.GetGroupedList(c => c.CourseId == CourseId);
                
            ViewBag.CourseId = CourseId;
            return View(Lessons);
        }

        // GET: Instructor/courseLessons/Details/5
        public IActionResult Details(int id)
        {
            if (_unitOfWork.courseLessons == null)
            {
                return NotFound();
            }

            var courseLessons =  _unitOfWork.courseLessons.GetById(id);
            if (courseLessons == null)
            {
                return NotFound();
            }

            return View(courseLessons);
        }

        // GET: Instructor/courseLessons/Create
        public IActionResult Create(int CourseId)
        {
            var media = _unitOfWork.MediaTypes.GetAll();

            SelectList mediaType = new SelectList(media, "Id", "Title", 0);
            ViewBag.media = mediaType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseLessons courseLessons)
        {
            string fileName = string.Empty;

            courseLessons.DateTimeItemAdded = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (courseLessons.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "CourseVideos");
                    fileName = courseLessons.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    courseLessons.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    courseLessons.Content = fileName;
                }
                _unitOfWork.courseLessons.Add(courseLessons);
                return RedirectToAction("Info", "Course", new { id = courseLessons.CourseId });
            }

        return View(courseLessons);
        }

        // GET: Instructor/courseLessons/Edit/5
        public IActionResult Edit(int id)
        {
            if (_unitOfWork.courseLessons == null)
            {
                return NotFound();
            }

            var courseLessons = _unitOfWork.courseLessons.GetById(id);
            if (courseLessons == null)
            {
                return NotFound();
            }
            var media = _unitOfWork.MediaTypes.GetAll();

            SelectList mediaType = new SelectList(media, "Id", "Title",0);
            ViewBag.media = mediaType;
            return View(courseLessons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,CourseLessons courseLessons)
        {
            courseLessons.DateTimeItemAdded = DateTime.Now;

            if (id != courseLessons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.courseLessons.Update(courseLessons);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!courseLessonsExists(courseLessons.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Info","Course",new {id = courseLessons.CourseId});
            }
            return View(courseLessons);
        }

        // GET: Instructor/courseLessons/Delete/5
        public IActionResult Delete(int id)
        {
            if (_unitOfWork.courseLessons == null)
            {
                return NotFound();
            }

            var courseLessons = _unitOfWork.courseLessons.GetById(id);
            if (courseLessons == null)
            {
                return NotFound();
            }

            return View(courseLessons);
        }

        // POST: Instructor/courseLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unitOfWork.courseLessons == null)
            {
                return Problem("Entity set 'AppDbContext.courseLessons'  is null.");
            }
            var courseLessons = _unitOfWork.courseLessons.GetById(id);
            if (courseLessons != null)
            {
                _unitOfWork.courseLessons.Delete(courseLessons);
            }
            
            return RedirectToAction(nameof(Index), new { CourseId = courseLessons.CourseId });
        }

        private bool courseLessonsExists(int id)
        {
          return _unitOfWork.courseLessons.GetById(id)!=null ? true : false;
        }
    }
}
