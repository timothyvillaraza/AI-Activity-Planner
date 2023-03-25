using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MLHAllinInOne2023.Models
{
    public class Weather
    {
        //TODO(1) - Populate this weather model class to populate the incoming weather JSON
        //look at the Location model for a bit of a reference
        [JsonProperty("current")]
        public JObject currentData {get;set;}


        public double Temperature { get; set; }

        public double FeelsLike { get; set; }
        public double RainAmount { get; set; }

        public string Text { get; set; }


        /// <summary>
        /// Requires the data to be loaded into currentData
        /// </summary>
        public void ManualParse()
        {
            this.Temperature = (double) currentData.GetValue("temp_f");
            this.FeelsLike = (double)currentData.GetValue("feelslike_f");
            this.RainAmount = (double)currentData.GetValue("precip_in");
            JObject conditions = (JObject)currentData.GetValue("condition");
            this.Text = (string) conditions.GetValue("text");
        }



        
    }
}
