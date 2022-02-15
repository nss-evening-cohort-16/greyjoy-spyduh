using Microsoft.AspNetCore.Mvc;

namespace Greyjoy_SpyDuh.Controllers
{
    public class SpyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
