using Microsoft.AspNetCore.Mvc;
using MLHAllinInOne2023.Services;
using OpenAI_API;

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
            // Open AI Setup
            /* OpenAIAPI api = new OpenAIAPI("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");

            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput("Write a bullet pointed list comparing Cats vs Dogs as pets.");
            string response = await chat.GetResponseFromChatbot();
            */

            string response = "success";
            BrowserParser bp = new BrowserParser(_httpContextAccessor);
            ViewBag.Location = bp.getBrowserLocationAsync();

            ViewBag.ChatGPTResponse = response;
            return View();
        }
    }
}
