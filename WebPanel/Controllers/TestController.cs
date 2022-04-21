using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebPanel.Controllers
{
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
