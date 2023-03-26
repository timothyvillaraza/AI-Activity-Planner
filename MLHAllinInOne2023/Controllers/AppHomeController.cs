using Microsoft.AspNetCore.Mvc;

namespace MLHAllinInOne2023.Controllers
{
    public class AppHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
