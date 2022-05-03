using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public StudentCourseController(IUnitOfWorkRepository unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddCourses(StudentCourseModel entry)
        {
            var student = _unitOfWork._studentRepositroy.GetByID(entry.StudentId);
            if (student.IsNull())
                return NotFound("Student not found");

            var courses = _unitOfWork._courseRepository.GetByIDs(entry.CourseIds);
            if (courses.IsNull())
                return NotFound("Course not found");

            var maxId = _unitOfWork._studentCourseRepository.GetAll().Count();

            var oldStudentCourses = _unitOfWork._studentCourseRepository.GetByStudentId(student.Id);

            var newStudentCourses = new List<StudentCourseDomain>();
            foreach (var item in courses)
            {
                if (oldStudentCourses.Any(r => r.CourseId == item.Id))
                    continue;
                newStudentCourses.Add(new StudentCourseDomain()
                {
                    CourseId = item.Id,
                    StudentId = student.Id,
                    Id = ++maxId
                });
            }

            _unitOfWork._studentCourseRepository.AddRange(newStudentCourses);

            return Ok("Success");
        }

        [HttpGet]
        public IActionResult GetCourses(long studentId)
        {
            var studentCourses = _unitOfWork._studentCourseRepository.GetByStudentId(studentId);
            if (studentCourses.IsNull())
                return NotFound("not anything found");

            var courses = _unitOfWork._courseRepository.GetByIDs(studentCourses.Select(r => r.CourseId).ToList());
            if (courses.IsNull())
                return NotFound("not anything found");

            return Ok(courses);
        }
    }
}
