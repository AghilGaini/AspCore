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
        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Test_Index_HttpGet)]
        [HttpGet]
        public IActionResult Index()
        {
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
