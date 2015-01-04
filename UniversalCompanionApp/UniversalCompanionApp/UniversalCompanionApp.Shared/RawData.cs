using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace UniversalCompanionApp
{
    public class RawData
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "geoLat")]
        public double? GeoLat { get; set; }
        [JsonProperty(PropertyName = "geoLng")]
        public double? GeoLng { get; set; }
        [JsonProperty(PropertyName = "accelX")]
        public double? AccelX { get; set; }
        [JsonProperty(PropertyName = "accelY")]
        public double? AccelY { get; set; }
        [JsonProperty(PropertyName = "accelZ")]
        public double? AccelZ { get; set; }
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime? TimeStamp { get; set; }
    }
}
