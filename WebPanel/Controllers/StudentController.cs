using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utilities;
using WebPanel.Filters;
using WebPanel.ViewModels;
using WebPanel.ViewModels.Student;

namespace WebPanel.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public StudentController(IUnitOfWorkRepository unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Student_Index_HttpGet)]
        [HttpGet]
        public IActionResult Index()
        {
            var res = new StudentViewModel();

            res.Students = _unitOfWork._studentRepositroy.GetAll().ToList();

            res.Actions.Add(new ActionItem()
            {
                Title = "Manage Courses",
                Action = "CreateStudentCourse",
                Controller = "Student",
            });

            return View(res);
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Student_Create_HttpGet)]
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Student_Create_HttpPost)]
        [HttpPost]
        public IActionResult Create(StudentDomain model)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new StudentDomain()
                {
                    Name = model.Name,
                    Age = model.Age,
                    NationalCode = model.NationalCode
                };

                if (_unitOfWork._studentRepositroy.IsDuplicateNationalCode(newStudent))
                    throw new System.Exception("Duplicate NationcalNumber");

                _unitOfWork._studentRepositroy.Add(newStudent);
                _unitOfWork.Complete();

                return RedirectToAction("Index");

            }

            return View();
        }

    }
}
