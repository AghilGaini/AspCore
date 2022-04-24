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

        [CustomAuthorization(permision: "7785109F-C308-4A7B-A46A-DFDC845A56DD")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [CustomAuthorization(permision: "4C529D65-E442-4CFE-9388-6B4F42C96B5C")]
        [HttpPost]
        public IActionResult Index(int i)
        {
            return View();
        }
    }
}
