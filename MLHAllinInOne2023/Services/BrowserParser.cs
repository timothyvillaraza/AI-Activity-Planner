using System.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using MLHAllinInOne2023.Models;
using Newtonsoft.Json;

namespace MLHAllinInOne2023.Services
{
    public class BrowserParser
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _url = "http://api.ipstack.com/67.184.71.173?access_key=ddb65bc8c92c247e38fc6b832c6c7da2";

        public BrowserParser(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }


        public async Task<string> getBrowserLocationAsync()
        {
            var ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            //http://api.ipstack.com/67.184.71.173?access_key=ddb65bc8c92c247e38fc6b832c6c7da2
            if (ip.Equals("::1", StringComparison.InvariantCultureIgnoreCase))
            {
                //default to Chicago maybe?
                ip = "67.184.71.173";
            }

            string url = $"http://api.stack.com/{ip}?access_key=ddb65bc8c92c247e38fc6b832c6c7da2";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url);

            string json = await response.Content.ReadAsStringAsync();
            //Location location = JsonConvert.DeserializeObject<Location>(json);

            return json;
        }
    }
}
