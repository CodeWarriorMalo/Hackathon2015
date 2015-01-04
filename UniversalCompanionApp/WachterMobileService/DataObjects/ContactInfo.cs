using Microsoft.WindowsAzure.Mobile.Service;

namespace WachterMobileService.DataObjects
{
    public class ContactInfo : EntityData
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string ContactName { get; set; }
        public int? IsPrimary { get; set; }
        public string ContactValue { get; set; }
    }
}