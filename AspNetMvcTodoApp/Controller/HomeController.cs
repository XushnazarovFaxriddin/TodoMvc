using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcTodoApp.Controller
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
