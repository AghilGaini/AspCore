using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IActionResult Index(string sortOrder)
        {

            ViewBag.NameSortParam = sortOrder.IsNull() ? "name_desc" : "";
            ViewBag.NationalCodeSortParam = sortOrder == "nationalCode" ? "nationalCode_desc" : "nationalCode";
            ViewBag.AgeSortParam = sortOrder == "age" ? "age_desc" : "age";
            var res = new StudentViewModel();



            switch (sortOrder)
            {
                case "name_desc":
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderByDescending(r => r.Name).ToList();
                    break;
                case "nationalCode":
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderBy(r => r.NationalCode).ToList();
                    break;
                case "nationalCode_desc":
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderByDescending(r => r.NationalCode).ToList();
                    break;
                case "age":
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderBy(r => r.Age).ToList();
                    break;
                case "age_desc":
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderByDescending(r => r.Age).ToList();
                    break;
                default:
                    res.Students = _unitOfWork._studentRepositroy.GetAll().OrderBy(r => r.Name).ToList();
                    break;
            }

            res.Actions.Add(new ActionItem()
            {
                Title = "Manage Courses",
                Action = "CreateStudentCourse",
                Controller = "Student",
            });

            return View(res);
        }

        #region Create
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
        #endregion

        #region CreateStudentCourse
        [CustomAuthorization(permision: PermisionManager.Permisions.Student_CreateStudentCourse_HttpGet)]
        [HttpGet]
        public IActionResult CreateStudentCourse(long studentId)
        {
            var student = _unitOfWork._studentRepositroy.GetByID(studentId);
            if (student.IsNull())
                throw new System.Exception("Student not found");

            var allCourses = _unitOfWork._courseRepository.GetAll().ToList();
            var studentCourses = _unitOfWork._studentCourseRepository.GetByStudentId(studentId);

            var res = new CreateStudentCourseViewModel()
            {
                StudentId = studentId
            };

            foreach (var item in allCourses)
            {
                if (studentCourses.Any(r => r.CourseId == item.Id))
                {
                    res.CourseInfos.Add(new CourseInfo()
                    {
                        CourseId = item.Id,
                        Title = item.Title,
                        IsSelected = true
                    });
                }
                else
                {
                    res.CourseInfos.Add(new CourseInfo()
                    {
                        CourseId = item.Id,
                        Title = item.Title,
                        IsSelected = false
                    });
                }
            }

            ViewBag.StudentName = student.Name;
            return View(res);
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Student_CreateStudentCourse_HttpPost)]
        [HttpPost]
        public IActionResult CreateStudentCourse(CreateStudentCourseViewModel model)
        {
            var student = _unitOfWork._studentRepositroy.GetByID(model.StudentId);
            if (student.IsNull())
                throw new System.Exception("student not found");

            var allStudentCourses = _unitOfWork._studentCourseRepository.GetByStudentId(student.Id);
            _unitOfWork._studentCourseRepository.RemoveRange(allStudentCourses);

            var newStudentCourses = new List<StudentCourseDomain>();

            foreach (var item in model.CourseInfos)
            {
                if (!item.IsSelected)
                    continue;
                newStudentCourses.Add(new StudentCourseDomain()
                {
                    CourseId = item.CourseId,
                    StudentId = student.Id
                });
            }
            _unitOfWork._studentCourseRepository.AddRange(newStudentCourses);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Student");
        }

        #endregion


    }
}
