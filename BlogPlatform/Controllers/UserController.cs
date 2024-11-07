using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class UserController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
