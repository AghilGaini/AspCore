using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;
using WebPanel.Filters;

namespace WebPanel.Controllers
{
    [CustomAuthorization(permision: "D85202DC-4C79-4FA3-816C-BD4E03EF93CE")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("test of logger");
            return View();
        }

        [HttpPost]
        public IActionResult Index(int i)
        {
            return View();
        }
    }
}
