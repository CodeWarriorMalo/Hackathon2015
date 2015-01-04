using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWachterService1
    {

        [OperationContract]
        WachterConfig GetConfiguration(string deviceId);
        [OperationContract]
        void SetConfiguration(WachterConfig config);
        [OperationContract]
        ContactInfo GetContact(string deviceId, string contactName);
        [OperationContract]
        ContactInfo[] GetContacts(string deviceId);
        [OperationContract]
        bool AddOrUpdateContact(ContactInfo contact);
        [OperationContract]
        bool RemoveContact(ContactInfo contact);
    }
    [DataContract]
    public class ContactInfo
    {
        private int _RecordId;
        private string _DeviceId;
        private string _ContactValue;
        private bool _IsPrimary;
        public int RecordId { get { return _RecordId; } }
        public string DeviceId { get { return _DeviceId; } set { _DeviceId = value; } }
        public string ContactValue { get { return _ContactValue; } set { _ContactValue = value; } }
        public bool IsPrimary { get { return _IsPrimary; } set { _IsPrimary = value; } }
    }
    [DataContract]
    public class WachterConfig
    {
        private int _RecordId;
        private string _DeviceId;
        private float _MinGeoLat;
        private float _MaxGeoLat;
        private float _MinGeoLng;
        private float _MaxGeoLng;
        public int RecordId { get { return _RecordId; } }
        public string DeviceId { get { return _DeviceId; } set { _DeviceId = value; } }
        public float MinGeoLat { get { return _MinGeoLat; } set { _MinGeoLat = value; } }
        public float MinGeoLng { get { return _MinGeoLng; } set { _MinGeoLng = value; } }
        public float MaxGeoLat { get { return _MaxGeoLat; } set { _MaxGeoLat = value; } }
        public float MaxGeoLng { get { return _MaxGeoLng; } set { _MaxGeoLng = value; } }
    }
}
