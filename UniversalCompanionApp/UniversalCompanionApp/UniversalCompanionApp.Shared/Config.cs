using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace UniversalCompanionApp
{
    public class Config
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty(PropertyName = "minGeoLat")]
        public double? MinGeoLat { get; set; }
        [JsonProperty(PropertyName = "minGeoLng")]
        public double? MinGeoLng { get; set; }
        [JsonProperty(PropertyName = "maxGeoLat")]
        public double? MaxGeoLat { get; set; }
        [JsonProperty(PropertyName = "maxGeoLng")]
        public double? MaxGeoLng { get; set; }
        [JsonProperty(PropertyName = "fallThreshold")]
        public double? FallThreshold { get; set; }

    }
}
