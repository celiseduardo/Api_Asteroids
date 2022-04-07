using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }
        [JsonProperty("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }
        [JsonProperty("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }
}
