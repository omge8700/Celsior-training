using Microsoft.AspNetCore.Mvc;

namespace CoreFirstApi.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
