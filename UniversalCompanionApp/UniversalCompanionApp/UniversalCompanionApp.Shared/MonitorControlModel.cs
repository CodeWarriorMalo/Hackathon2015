using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalCompanionApp
{
    public class MonitorControlModel
    {
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }
        public double? MinGeoLat { get; set; }
        public double? MinGeoLng { get; set; }
        public double? MaxGeoLat { get; set; }
        public double? MaxGeoLng { get; set; }
        public double? FallThreshold { get; set; }
        public string ContactName { get; set; }
        public int? IsPrimary { get; set; }
        public string ContactValue { get; set; }
    }
}
