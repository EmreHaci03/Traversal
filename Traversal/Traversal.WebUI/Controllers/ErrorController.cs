using Microsoft.AspNetCore.Mvc;

namespace Traversal.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult NotFound()
        {
            return View();
        }

        [Route("Error/401")]
        public IActionResult Unauthorized()
        {
            return View();
        }

        [Route("Error/403")]
        public IActionResult Forbidden()
        {
            return View();
        }

        [Route("Error/{StatusCode}")]
        public IActionResult Error(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    return View("NotFound");
                case 401:
                    return View("Unauthorized");
                case 403:
                    return View("Forbidden");
                default:
                    return View("Error");
            }
        }


    }
}
