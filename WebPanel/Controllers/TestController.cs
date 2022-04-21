using Microsoft.AspNetCore.Mvc;

namespace WebPanel.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int i)
        {
            return View();
        }
    }
}
