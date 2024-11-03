using FigmaToHtml.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FigmaToHtml.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController1(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(Index);
        }
        public IActionResult Privacy()
        {
            return View(Privacy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
