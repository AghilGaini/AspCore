using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utilities;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public CourseController(IUnitOfWorkRepository unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _unitOfWork._courseRepository.GetAll();
            if (res.Count() != 0)
                return Ok(res);

            return NotFound("not any thin found");
        }

        [HttpGet]
        public IActionResult GetById(long id)
        {
            var res = _unitOfWork._courseRepository.GetByID(id);
            if (res.IsNotNull())
                return Ok(res);

            return NotFound("not any thin found");
        }

        [HttpPost]
        public IActionResult Add(CourseDomain entry)
        {
            if (entry.Id != 0)
                return BadRequest("Id is not Zero!!");

            if (_unitOfWork._courseRepository.IsDuplicateTitle(entry))
                return BadRequest("Duplicate Title");

            _unitOfWork._courseRepository.Add(entry);
            _unitOfWork.Complete();

            return Ok("Success");

        }

    }
}
