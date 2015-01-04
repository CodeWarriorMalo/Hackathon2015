using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UniversalCompanionApp
{
    public class MonitorControlViewModel : INotifyPropertyChanged
    {
        private MonitorControlModel _Model;
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
        }
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
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
