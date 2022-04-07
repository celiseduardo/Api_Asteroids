using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
