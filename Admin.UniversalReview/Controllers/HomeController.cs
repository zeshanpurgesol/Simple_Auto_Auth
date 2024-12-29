using Admin.UniversalReview.Models;
using DAL.Services;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.UniversalReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPageService _pageService;

        public HomeController(ILogger<HomeController> logger, IPageService pageService)
        {
            _logger = logger;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Pages()
        {
            var list = _pageService.GetAllPage();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPage(PageViewModel model)
        {
           
           var res= await _pageService.AddPage(model);
            return RedirectToAction("Pages");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
