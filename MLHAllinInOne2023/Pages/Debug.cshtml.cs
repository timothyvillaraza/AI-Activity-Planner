using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using MLHAllinInOne2023.Models;
using MLHAllinInOne2023.Services;

namespace MLHAllinInOne2023.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class DebugModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<DebugModel> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public BrowserModel bParser { get; set; }
        public WeatherModel weatherModel { get; set; }

        public OpenAIResponse chatResponse { get; set; }
        public DebugModel(ILogger<DebugModel> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClient = new HttpClient();

        }

        public void OnGet()
        {
            bParser = new BrowserModel(_contextAccessor);
            weatherModel = new WeatherModel(bParser.geoData.Latitude, bParser.geoData.Longitude);
            OpenAIService chatGPT = new OpenAIService(_configuration, _httpClient);
            //TODO - figure out how to populate this prompt with something the user inputs
            string prompt = "What is the meaning of life";

            chatResponse = chatGPT.GenerateText(prompt).Result;
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}