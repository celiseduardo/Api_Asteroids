using Newtonsoft.Json;
using System;

namespace WebAPI.Models
{
    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public DateTime CloseApproachDate { get; set; }
        [JsonProperty("close_approach_date_full")]
        public DateTime CloseApproachDateFull { get; set; }
        [JsonProperty("epoch_date_close_approach")]
        public object EpochDateCloseApproach { get; set; }
        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }
        [JsonProperty("miss_distance")]
        public MissDistance MissDistance { get; set; }
        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }
}
