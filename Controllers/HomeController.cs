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
            return RedirectToAction("Index", "Home");
        }
            public ActionResult GetUsers(string type)
        {
            var business = new UsersBusiness();
            var users = business.GetUsers(type);
            return View(users);
        }
        //public ActionResult GetUserById(int UserId)
        //{
        //    var business = new UsersBusiness();
        //    var user = business.GetUserById(UserId);
        //    return View(user);
        //}
        public ActionResult EditUser(int userId)
        {
            var user = new UsersBusiness().GetUserById(userId);
            return  View(user);
        }
        public ActionResult UpdateUser(UsersViewModel model)
        {
            new UsersBusiness().UpdateUser(model);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}