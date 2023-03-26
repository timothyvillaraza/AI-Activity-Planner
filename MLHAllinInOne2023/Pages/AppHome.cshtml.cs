using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MLHAllinInOne2023.Pages
{
    public class AppHomeModel : PageModel
    { 
        // checkboxes display on page 
        public string[] intrests = {
            "art",
            "food",
            "nature",
            "nightlife",
            "music"
        };

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

        public bool ShowForm { get; set; } // get request = true, post request = false

        public void OnGet()
        {
            ShowForm = true;
        }

        public void OnPost()
        {
            ShowForm = false;
            ViewData["Message"] = "Other Intrests: " + otherIntrests + " " + art;
        }
    }
}
