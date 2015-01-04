using Microsoft.WindowsAzure.Mobile.Service;

namespace WachterMobileService.DataObjects
{
    public class Config : EntityData
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public double? MinGeoLat { get; set; }
        public double? MinGeoLng { get; set; }
        public double? MaxGeoLat { get; set; }
        public double? MaxGeoLng { get; set; }
        public double? FallThreshold { get; set; }
    }
}