using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MLHAllinInOne2023.Pages
{
    public class AppHomeModel : PageModel
    { 

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
            ShowForm = false;
            //creates a string of the checkboxes
            if (art) {allIntrests += "art, "; }
            if (food) { allIntrests += "food, "; }
            if (nature) { allIntrests += "nature, "; }
            if (nightlife) { allIntrests += "nightlife, "; }
            if (music) { allIntrests += "music, "; }

            ViewData["intrests"] = allIntrests;
            ViewData["otherIntrests"] = otherIntrests;

        }
    }
}
