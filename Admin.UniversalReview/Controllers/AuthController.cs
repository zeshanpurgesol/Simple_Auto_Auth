using DAL.Services;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Admin.UniversalReview.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = userService.GetAllUser().Where(x =>x.Password==model.Password && (x.Email.ToLower() == model.UserName.ToLower() || x.UserName.ToLower() == model.UserName.ToLower())).Count();
            if (user == 0)
            {
                ViewBag.data = "Invalid UserName or Passowrd!";
                return View();
            }
            HttpContext.Session.SetString("S_name",model.UserName);
            return RedirectToAction("Index","Home");
          
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            var dd = HttpContext.Session.GetString("S_name");
            return View();
        }
        public IActionResult Logout()
        {
           // HttpContext.Session.Clear();
            HttpContext.Session.Remove("S_name");
            return RedirectToAction("Login");
        }
    }
}
