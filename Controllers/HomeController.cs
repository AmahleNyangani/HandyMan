using HandyMan.Business;
using HandyMan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using HandyMan.ViewModel;
using PagedList;

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
        public IActionResult AboutUs()
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
        public ActionResult GetUsers(string type, int page = 1)
        {
            int pageSize = 10; // Number of items per page
            var business = new UsersBusiness();
            var users = business.GetUsers(type); // Retrieve the list of users based on the type

            // Convert the list of users to a paged list
            var pagedList = users.ToPagedList(page, pageSize);

            // Pass the paged list to the view
            return View(pagedList);
        }
        //public ActionResult GetUserById(int UserId)
        //{
        //    var business = new UsersBusiness();
        //    var user = business.GetUserById(UserId);
        //    return View(user);
        //}
        public ActionResult ViewUserProfile(int userId)
        {
            var user = new UsersBusiness().GetUserById(userId);
            return  View(user);
        }
        public ActionResult EditUser(int userId)
        {
            var user = new UsersBusiness().GetUserById(userId);
            return View(user);
        }
        public ActionResult HireUser(CustomerViewModel model)
        {
            var business = new UsersBusiness();
            business.HireUser(model);
            return View();
        }

        public ActionResult UpdateUser(UsersViewModel model)
        {
            new UsersBusiness().UpdateUser(model);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}