using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MLHAllinInOne2023.Models;
using MLHAllinInOne2023.Services;
using OpenAI_API.Models;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MLHAllinInOne2023.Pages
{
    public class AppHomeModel : PageModel
    {

     
        //TODO - figure out how to populate this prompt with something the user inputs
        public string[] ResponseArray { get; set; }
        public BrowserModel bParser { get; set; }


        private readonly ILogger<AppHomeModel> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AppHomeModel(ILogger<AppHomeModel> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClient = new HttpClient();
            ResponseArray = new string[0];

        }


        public OpenAIResponse chatResponse { get; set; }

        public string allIntrests;

        [BindProperty]
        public string otherIntrests { get; set; }
        [BindProperty]
        public bool art { get; set; }
        [BindProperty]
        public bool food { get; set; }
        [BindProperty]
        public bool nature { get; set; }
        [BindProperty]
        public bool nightlife { get; set; }
        [BindProperty]
        public bool music { get; set; }

        // checkboxes display on page 
        public bool ShowForm { get; set; } // get request = true, post request = false

        public void OnGet()
        {

            ShowForm = true;
        }

        public void OnPost()
        {
            OpenAIService chatGPT = new OpenAIService(_configuration, _httpClient);
            bParser = new BrowserModel(_contextAccessor);
            ShowForm = false;
            //creates a string of the checkboxes
            if (art) {allIntrests += "art, "; }
            if (food) { allIntrests += "food, "; }
            if (nature) { allIntrests += "nature, "; }
            if (nightlife) { allIntrests += "nightlife, "; }
            if (music) { allIntrests += "music, "; }

            ViewData["intrests"] = allIntrests;
            ViewData["otherIntrests"] = otherIntrests;

            string prompt = @"Generate an itinerary of places to visit in a day in or around, " +  bParser.geoData.City + ", " + bParser.geoData.Region +
                @".List places for a person interested in" + allIntrests + otherIntrests + ".Give start and end times for each place.";

            chatResponse = chatGPT.GenerateText(prompt).Result;
            string Response = "";

            foreach (var choice in chatResponse.choices)
            {
                Response += @choice.message.content;
            }

            ResponseArray = Response.Split("\n");
            ResponseArray= ResponseArray.Skip(1).ToArray();
        }
    }
}
