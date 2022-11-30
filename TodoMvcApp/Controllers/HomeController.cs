using Microsoft.AspNetCore.Mvc;

namespace TodoMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Todo()
        {
            int todoCount = 154;
            return View(todoCount);
        }
    }
}
