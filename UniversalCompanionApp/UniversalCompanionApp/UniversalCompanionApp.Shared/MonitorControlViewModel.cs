using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UniversalCompanionApp
{
    public class MonitorControlViewModel : INotifyPropertyChanged
    {
        private MonitorControlModel _Model = new MonitorControlModel();
        public MonitorControlModel Model { get { return _Model;} set { _Model = value; RaisePropertyChanged();}}
        private void RaisePropertyChanged()
        {

            PropertyChanged(this, new PropertyChangedEventArgs("DeviceName"));
            PropertyChanged(this, new PropertyChangedEventArgs("DeviceId"));
            PropertyChanged(this, new PropertyChangedEventArgs("MinGeoLat"));
            PropertyChanged(this, new PropertyChangedEventArgs("MinGeoLng"));
            PropertyChanged(this, new PropertyChangedEventArgs("MaxGeoLat"));
            PropertyChanged(this, new PropertyChangedEventArgs("MaxGeoLng"));
            PropertyChanged(this, new PropertyChangedEventArgs("FallThreshold"));
            PropertyChanged(this, new PropertyChangedEventArgs("ContactName"));
            PropertyChanged(this, new PropertyChangedEventArgs("IsPrimary"));
            PropertyChanged(this, new PropertyChangedEventArgs("ContactValue"));
            PropertyChanged(this, new PropertyChangedEventArgs("ContactPerson"));
        }

        public string DeviceName { get { return _Model.DeviceName; } set { _Model.DeviceName = value; if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DeviceName")); }}
        public string DeviceId { get { return _Model.DeviceId; } set { _Model.DeviceName = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DeviceId")); } }
        public double? MinGeoLat { get { return _Model.MinGeoLat; } set { _Model.MinGeoLat = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MinGeoLat")); } }
        public double? MinGeoLng { get { return _Model.MinGeoLng; } set { _Model.MinGeoLng = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MinGeoLng")); } }
        public double? MaxGeoLat { get { return _Model.MaxGeoLat; } set { _Model.MaxGeoLat = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MaxGeoLat")); } }
        public double? MaxGeoLng { get { return _Model.MaxGeoLng; } set { _Model.MaxGeoLng = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MaxGeoLng")); } }
        public double? FallThreshold { get { return _Model.MaxGeoLng; } set { _Model.MaxGeoLng = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MaxGeoLng")); } }
        public string ContactPerson { get { return string.Format("{0} - {1}", _Model.ContactName, _Model.ContactValue); } }
        public string ContactName { get { return _Model.ContactName; } set { _Model.ContactName = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ContactName")); } }
        public int? IsPrimary { get { return _Model.IsPrimary; } set { _Model.IsPrimary = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsPrimary")); } }
        public string ContactValue { get { return _Model.ContactValue; } set { _Model.ContactValue = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ContactValue")); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
