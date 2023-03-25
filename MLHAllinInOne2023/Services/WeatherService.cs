using System.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using MLHAllinInOne2023.Models;
using Newtonsoft.Json;

namespace MLHAllinInOne2023.Services
{
    public class WeatherService
    {
        private string _url = "";

        public WeatherService()
        {

        }

        public async Task<string> getWeather(double latitude, double longitude)
        {
            _url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url);

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
