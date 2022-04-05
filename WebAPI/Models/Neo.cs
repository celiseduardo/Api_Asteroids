using Newtonsoft.Json;
using System.Collections.Generic;


namespace WebAPI.Models
{     
    public class Neo
    {
        [JsonProperty("links")]
        public Links Links { get; set; }
        [JsonProperty("element_count")]
        public int ElementCount { get; set; }
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, NearEarthObjects[]> NearEarthObjects { get; set; }

    }

}
