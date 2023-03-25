using Microsoft.AspNetCore.Mvc;
using MLHAllinInOne2023.Services;

namespace MLHAllinInOne2023.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            BrowserParser bp = new BrowserParser(_httpContextAccessor);
            ViewBag.Location = bp.getBrowserLocationAsync();
            return View();
        }
    }
}
