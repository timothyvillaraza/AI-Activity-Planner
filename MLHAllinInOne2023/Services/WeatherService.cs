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
            string betterUrl = $"http://api.weatherapi.com/v1/current.json?key=0b27dc041ff74b339f9194757232503&q={latitude},{longitude}";
            //_url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&models=best_match";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(betterUrl);

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
