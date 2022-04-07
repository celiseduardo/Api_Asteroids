using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Diameters
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
