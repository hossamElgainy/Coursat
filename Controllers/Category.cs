using Coursat.Repository;
using Coursat.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Coursat.Controllers
{
    public class Category : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public Category(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.Categories.GetAll());
        }
    }
}
