using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }
        [JsonProperty("prev")]
        public string Prev { get; set; }
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
