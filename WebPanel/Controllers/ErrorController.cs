using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebPanel.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this._logger = logger;
        }

        [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry,The resource that requested not found";
                    _logger.LogError("Sorry, The resource that requested not found");
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, Something is wrong";
                    _logger.LogError("Sorry, Something is wrong");
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ErrorMessage = exceptionDetails.Error.Message;

            _logger.LogError(exceptionDetails.Error.Message);

            return View();
        }

    }
}
