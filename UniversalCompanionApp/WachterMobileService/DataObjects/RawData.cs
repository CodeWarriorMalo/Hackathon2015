using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace WachterMobileService.DataObjects
{
    public class RawData : EntityData
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