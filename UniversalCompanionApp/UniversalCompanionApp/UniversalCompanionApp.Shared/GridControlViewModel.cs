using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UniversalCompanionApp
{
    public class GridControlViewModel: INotifyPropertyChanged
    {
        private GridControlModel _Model;
        public GridControlViewModel(GridControlModel model)
        {
            Model = model;
        }
        public Brush RowColor
        {
            get
            {
                return _Model.RowIndex % 2 == 0 ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.DarkGray);
            }
        }
        public float FontSize
        {
            get
            {
                float fs = 20;
#if WINDOWS_PHONE_APP

            fs = 12;

#endif
                return fs;
            }
        }
        private bool _IsHighlighted;
        public bool IsHighlighted
        {
            get
            {
                return _IsHighlighted;
            }
            set
            {
                _IsHighlighted = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ShinyColor"));
            }
        }
        public Brush ShinyColor
        {
            get
            {
                return _IsHighlighted ? new SolidColorBrush(Colors.LightGoldenrodYellow) : new SolidColorBrush(Colors.Transparent);
            }
        }
        public GridControlModel Model
        {
            get
            {
                return _Model;
            }
            set
            {
                _Model = value;
            }
        }
        public string DeviceId
        {
            get
            {
                return _Model.Config.Id.ToString();
            }
        }
        public string DeviceName
        {
            get
            {
                return _Model.Config.DeviceId;
            }
        }
        public string Latitude
        {
            get
            {
                return _Model.Data.GeoLat.ToString();
            }
        }
        public string Longitude
        {
            get
            {
                return _Model.Data.GeoLng.ToString();
            }
        }
        public string Threshold
        {
            get
            {
                if (_Model.Config.FallThreshold < 3) return "Low";
                if (_Model.Config.FallThreshold > 4) return "High";
                return "Medium";
            }
        }
        public string Incidents
        {
            get
            {
                return _Model.IncidentCount.ToString();
            }
        }
        public string Contact
        {
            get
            {
                return _Model.Contact.ContactName;
            }
        }
        public string ContactValue
        {
            get
            {
                return _Model.Contact.ContactValue;
            }
        }
        public string Status
        {
            get
            {
                return "Active";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
