using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversalCompanionApp.Models
{
    public class Config
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public double? MinGeoLat { get; set; }
        public double? MinGeoLng { get; set; }
        public double? MaxGeoLat { get; set; }
        public double? MaxGeoLng { get; set; }
        public double? FallThreshold { get; set; }
    }
    public class ContactInfo
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string ContactName { get; set; }
        public int? IsPrimary { get; set; }
        public string ContactValue { get; set; }
    }
    public class RawData 
    {
        public int Id { get; set; }
        public double? GeoLat { get; set; }
        public double? GeoLng { get; set; }
        public double? AccelX { get; set; }
        public double? AccelY { get; set; }
        public double? AccelZ { get; set; }
        public string DeviceId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}