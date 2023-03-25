using Microsoft.AspNetCore.Mvc;
using MLHAllinInOne2023.Services;
using OpenAI_API;

namespace MLHAllinInOne2023.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IOpenAIService _openAIService;

        public HomeController(IHttpContextAccessor httpContextAccessor, IOpenAIService openAIService)
        {
            _httpContextAccessor = httpContextAccessor;
            _openAIService = openAIService;
        }
        public IActionResult Index()
        {
            var response = _openAIService.GenerateText("List 5 reasons why cats are so awsome!");
            BrowserParser bp = new BrowserParser(_httpContextAccessor);
            ViewBag.Location = bp.getBrowserLocationAsync();

            ViewBag.ChatGPTResponse = response;
            return View();
        }
    }
}
