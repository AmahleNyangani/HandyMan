using Microsoft.AspNetCore.Mvc;

namespace HandyMan.Controllers
{
    public class UsersController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
