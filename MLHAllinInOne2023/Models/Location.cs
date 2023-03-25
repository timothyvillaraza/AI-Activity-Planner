using Newtonsoft.Json;

namespace MLHAllinInOne2023.Models
{
    public class Location
    {
        [JsonProperty(PropertyName = "country_name")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "region_code")]
        public string Region { get; set; }
        public string City { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zip { get; set; }
    }
}
