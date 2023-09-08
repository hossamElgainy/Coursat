using Coursat.Data;
using Coursat.Models;
using Coursat.Repository;
using Coursat.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Coursat.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(AppDbContext context, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? id)
        {
            if(id == null)
            {
                var CurrentUser = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
                return View(CurrentUser);
            }
            else
            {
                var CurrentUser = await _userManager.FindByIdAsync(id);
                return View(CurrentUser);
            }

        }        
        public IActionResult GetLinks()
        {
            var links = _unitOfWork.Links.SelectOne(z => z.UserId == _userManager.GetUserId(User));
            return PartialView("_GetLinks",links);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLinks(UserLinks links)
        {
            links.UserId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {                
                _unitOfWork.Links.Add(links);
                return RedirectToAction(nameof(Index));
            }
            return View(links);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLinks(UserLinks links)
        {

            if (ModelState.IsValid)
            {                
                _unitOfWork.Links.Update(links);
                return RedirectToAction(nameof(Index));
            }
            return View(links);
        }
    }
}
