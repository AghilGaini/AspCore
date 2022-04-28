using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utilities;
using WebPanel.Filters;
using WebPanel.ViewModels.Course;

namespace WebPanel.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public CourseController(IUnitOfWorkRepository unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Course_Index_HttpGet)]
        [HttpGet]
        public IActionResult Index()
        {

            var res = new CourseViewModel();
            res.Courses = _unitOfWork._courseRepository.GetAll().ToList();

            return View(res);
        }

        #region Create
        [CustomAuthorization(permision: PermisionManager.Permisions.Course_Create_HttpGet)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Course_Create_HttpPost)]
        [HttpPost]
        public IActionResult Create(CourseDomain model)
        {
            if (ModelState.IsValid)
            {
                var newCourse = new CourseDomain()
                {
                    Title = model.Title
                };

                if (_unitOfWork._courseRepository.IsDuplicateTitle(newCourse))
                    throw new System.Exception("Duplicate Title");

                _unitOfWork._courseRepository.Add(newCourse);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

    }
}
