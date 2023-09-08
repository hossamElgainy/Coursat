using Coursat.Data;
using Coursat.Models;
using Coursat.Repository.Base;
using Coursat.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coursat.Controllers
{
    public class CourseLessonsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseLessonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int id,int? LessonId)
        {
            var courseLessons = _unitOfWork.courseLessons.GetGroupedList(z => z.CourseId == id);
            if(LessonId!=null)
            {
                var Lesson = _unitOfWork.courseLessons.SelectOne(z => z.Id == LessonId);

                ViewBag.Lesson = Lesson;
            }
            else
            {
                ViewBag.Lesson = courseLessons.FirstOrDefault();
            }

            return View(courseLessons);
        }

    }
}
