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
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public StudentController(IUnitOfWorkRepository unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _unitOfWork._studentRepositroy.GetAll();
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetById(long id)
        {
            var res = _unitOfWork._studentRepositroy.GetByID(id);
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Add(StudentDomain entry)
        {
            var student = _unitOfWork._studentRepositroy.GetByID(entry.Id);
            if (student.IsNotNull())
                return NotFound();

            if (_unitOfWork._studentRepositroy.IsDuplicateNationalCode(entry))
                return BadRequest("Adam bash tekrari nazan");


            student = new StudentDomain()
            {
                NationalCode = entry.NationalCode,
                Age = entry.Age,
                Name = entry.Name
            };

            _unitOfWork._studentRepositroy.Add(student);
            _unitOfWork.Complete();

            return Ok("Success");
        }
    }
}
