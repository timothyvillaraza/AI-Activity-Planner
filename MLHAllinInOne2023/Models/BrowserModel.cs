using Microsoft.AspNetCore.Http;
using MLHAllinInOne2023.Services;
using Newtonsoft.Json;

namespace MLHAllinInOne2023.Models
{
    public class BrowserModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BrowserParser _browserService;

       
        public Location geoData { get; set; }
        public BrowserModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _browserService = new BrowserParser(_httpContextAccessor);
            string jsonData = _browserService.getBrowserLocationAsync().Result;

            geoData = JsonConvert.DeserializeObject<Location>(jsonData);


        }

    }
}
