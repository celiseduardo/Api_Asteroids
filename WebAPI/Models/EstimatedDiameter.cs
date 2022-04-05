using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Diameters Kilometers { get; set; }
        [JsonProperty("meters")]
        public Diameters Meters { get; set; }
        [JsonProperty("miles")]
        public Diameters Miles { get; set; }
        [JsonProperty("links")]
        public Diameters Feet { get; set; }
    }
}
