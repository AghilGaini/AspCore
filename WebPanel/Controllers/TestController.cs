using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;
using WebPanel.Filters;

namespace WebPanel.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public TestController(ILogger<TestController> logger, IUnitOfWorkRepository unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Test_Index_HttpGet, rolesName: "Basic")]
        [HttpGet]
        public IActionResult Index()
        {
            var res = _unitOfWork._vwUserRolePermisionRepository.GetAll();
            return View();
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Test_Index_HttpPost)]
        [HttpPost]
        public IActionResult Index(int i)
        {
            return View();
        }
    }
}
