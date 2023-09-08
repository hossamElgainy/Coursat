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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Coursat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MediaTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/MediaTypes
        public IActionResult Index()
        {
              return _unitOfWork.MediaTypes != null ? 
                          View(_unitOfWork.MediaTypes.GetAll()) :
                          Problem("Entity set 'AppDbContext.MediaTypes'  is null.");
        }

        // GET: Admin/MediaTypes/Details/5
        public IActionResult Details(int id)
        {
            if (_unitOfWork.MediaTypes == null)
            {
                return NotFound();
            }

            var mediaTypes = _unitOfWork.MediaTypes.GetById(id);
            if (mediaTypes == null)
            {
                return NotFound();
            }

            return View(mediaTypes);
        }

        // GET: Admin/MediaTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MediaTypes.Add(mediaType);
                return RedirectToAction(nameof(Index));
            }
            return View(mediaType);
        }

        // GET: Admin/MediaTypes/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || _unitOfWork.MediaTypes == null)
            {
                return NotFound();
            }

            var mediaTypes =  _unitOfWork.MediaTypes.GetById(id);
            if (mediaTypes == null)
            {
                return NotFound();
            }
            return View(mediaTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ThumbnailImagePath")] MediaType mediaType)
        {
            if (id != mediaType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.MediaTypes.Update(mediaType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaTypesExists(mediaType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mediaType);
        }

        // GET: Admin/MediaTypes/Delete/5
        public IActionResult Delete(int id)
        {
            if (_unitOfWork.MediaTypes == null)
            {
                return NotFound();
            }

            var mediaTypes =  _unitOfWork.MediaTypes.GetById(id);
            if (mediaTypes == null)
            {
                return NotFound();
            }

            return View(mediaTypes);
        }

        // POST: Admin/MediaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unitOfWork.MediaTypes == null)
            {
                return Problem("Entity set 'AppDbContext.MediaTypes'  is null.");
            }
            var mediaType =  _unitOfWork.MediaTypes.GetById(id);
            if (mediaType != null)
            {
                _unitOfWork.MediaTypes.Delete(mediaType);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MediaTypesExists(int id)
        {
            return _unitOfWork.MediaTypes.GetById(id) != null ? true : false;
        }
    }
}
