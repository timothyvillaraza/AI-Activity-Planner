using Microsoft.AspNetCore.Http;
using MLHAllinInOne2023.Services;
using Newtonsoft.Json;

namespace MLHAllinInOne2023.Models
{
    public class WeatherModel
    {
        private readonly WeatherService _weatherService;

        public string _jsonOutput;

        public Weather _weather { get; set; }
        public WeatherModel(double latitude, double longitude)
        {
            _weatherService = new WeatherService();
            _jsonOutput = _weatherService.getWeather(latitude, longitude).Result;

            //TODO(2) deserialize the JSON data into the _weather object. See BrowserModel on how to do that.

        }

    }
}
