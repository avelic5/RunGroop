using Microsoft.AspNetCore.Mvc;

namespace RunGroopWebApp.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
