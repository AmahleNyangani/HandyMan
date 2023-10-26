using HandyMan.Business;
using HandyMan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using HandyMan.ViewModel;

namespace HandyMan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(UsersViewModel model)
        {
            var business = new UsersBusiness();
            business.AddUser(model);
            return View();
        }
            public ActionResult GetUsers()
        {
            var business = new UsersBusiness();
            var model = business.GetUsers();
            return View(model);
        }
        public ActionResult GetUserById(int id)
        {
            var business = new UsersBusiness();
            var model = business.GetUserById(id);
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}