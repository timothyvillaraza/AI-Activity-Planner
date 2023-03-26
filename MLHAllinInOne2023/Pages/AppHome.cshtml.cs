using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MLHAllinInOne2023.Pages
{
    public class AppHomeModel : PageModel
    {
        [BindProperty]
        public string otherIntrests { get; set; }
        public string[] intrests = { "art", "food", "nature", "nightlife", "music" };
        public bool ShowForm { get; set; }//get request = true, post request = false

        public void OnGet()
        {
            ShowForm = true;
        }
        
        public void OnPost()
        {
            ShowForm = false;
            ViewData["Message"] = "Other Intrests: " + otherIntrests;
        }
    }
}
