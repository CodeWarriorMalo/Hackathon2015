using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace UniversalCompanionApp
{
    public class ContactInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty(PropertyName = "contactName")]
        public string ContactName { get; set; }
        [JsonProperty(PropertyName = "isPrimary")]
        public int? IsPrimary { get; set; }
        [JsonProperty(PropertyName = "contactValue")]
        public string ContactValue { get; set; }

    }
}
