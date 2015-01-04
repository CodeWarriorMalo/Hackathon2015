using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UniversalCompanionApp
{
    public sealed partial class DeviceControl : UserControl
    {
        public delegate void DeviceEventHandler(string deviceId, string lat, string lng, bool selected);
        public event DeviceEventHandler OnDeviceEvent;
        private DeviceControlViewModel _ViewModel = new DeviceControlViewModel();
        public DeviceControl()
        {
            this.InitializeComponent();
            DataContext = _ViewModel;
        }

        private void LoadData()
        {

        }

        public MonitorControlViewModel GetMonitorControlViewModel(string deviceId)
        {
            MonitorControlViewModel mcvm = new MonitorControlViewModel();
            var item = viewModels.Find(p => p.DeviceId == deviceId);
            mcvm.ContactName = item.Contact;
            mcvm.ContactValue = item.ContactValue;
            mcvm.DeviceId = item.DeviceId;
            mcvm.DeviceName = item.DeviceName;
            mcvm.FallThreshold = item.Threshold == "High" ? (item.Threshold == "Low" ? 2 : 3) : 4;
     //       mcm.FallThreshold = double.Parse(item.Threshold);
            mcvm.MaxGeoLat = double.Parse(item.Latitude) - .05;
            mcvm.MinGeoLat = double.Parse(item.Latitude) + .05;
            mcvm.MinGeoLng = double.Parse(item.Longitude) - .05;
            mcvm.MaxGeoLng = double.Parse(item.Longitude) + .05;
            return mcvm;
        }
        private List<GridControlViewModel> viewModels;
        private void MockData()
        {
            viewModels = new List<GridControlViewModel>();
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Al Simars", FallThreshold = 2, Id = 1 }, Contact = new ContactInfo() { ContactValue="Son",  ContactName = "Bobby Simars" }, Data = new RawData() { GeoLat = 36.11469, GeoLng = -115.19411 }, IncidentCount = 5, RowIndex = 0 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Dee Mensha", FallThreshold = 4, Id = 2 }, Contact = new ContactInfo() { ContactValue = "Daughter", ContactName = "Jessica Simars" }, Data = new RawData() { GeoLat = 36.11448, GeoLng = -115.19562 }, IncidentCount = 2, RowIndex = 1 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Sideshow Bob", FallThreshold = 6, Id = 3 }, Contact = new ContactInfo() { ContactValue = "Bratty Kid", ContactName = "Bart Simpson" }, Data = new RawData() { GeoLat = 36.11357, GeoLng = -115.19431 }, IncidentCount = 15, RowIndex = 2 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Phil Dacartup", FallThreshold = 1, Id = 4 }, Contact = new ContactInfo() { ContactValue = "Singer", ContactName = "Jessica Simpson" }, Data = new RawData() { GeoLat = 36.11446, GeoLng = -115.18034 }, IncidentCount = 4, RowIndex = 3 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Keri Onyanoot", FallThreshold = 3, Id = 5 }, Contact = new ContactInfo() { ContactValue = "Son-in-Law", ContactName = "Bart McSimple" }, Data = new RawData() { GeoLat = 36.11365, GeoLng = -115.18563 }, IncidentCount = 6, RowIndex = 4 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Acturo Baker", FallThreshold = 2, Id = 6 }, Contact = new ContactInfo() { ContactValue = "R2D2", ContactName = "Kenny Baker" }, Data = new RawData() { GeoLat = 36.11454, GeoLng = -115.19001 }, IncidentCount = 1, RowIndex = 5 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Sid Viscous", FallThreshold = 4, Id = 7 }, Contact = new ContactInfo() { ContactValue = "Bandmate", ContactName = "Johnny Rotten" }, Data = new RawData() { GeoLat = 36.11243, GeoLng = -115.19427 }, IncidentCount = 1, RowIndex = 6 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Joey Ramone", FallThreshold = 2, Id = 8 }, Contact = new ContactInfo() { ContactValue = "Bandmate", ContactName = "Kenny Ramone" }, Data = new RawData() { GeoLat = 36.11462, GeoLng = -115.17815 }, IncidentCount = 0, RowIndex = 7 }));
            viewModels.Add(new GridControlViewModel(new GridControlModel() { Config = new Config() { DeviceId = "Trixie Hobbit", FallThreshold = 1, Id = 9 }, Contact = new ContactInfo() { ContactValue = "Nasty Hobbitses", ContactName = "Frodo Baggins" }, Data = new RawData() { GeoLat = 36.11351, GeoLng = -115.19342 }, IncidentCount = 3, RowIndex = 8 }));

            int gcId = 1;
            foreach (var vm in viewModels)
            {
                OnDeviceEvent(vm.DeviceId, vm.Latitude, vm.Longitude, false);
                GridControl gc = new GridControl(vm);
                gc.OnSelected += gc_OnSelected;
                gc.Name = string.Format("gridControl{0}", gcId);
                gc.SetValue(Grid.ColumnProperty, 0);
                gc.SetValue(Grid.ColumnSpanProperty, 7);
                gc.SetValue(Grid.RowProperty, gcId);
                gcId++;
                DeviceGrid.Children.Add(gc);
            }
        }

        void gc_OnSelected(UserControl control)
        {
            var gc = control as GridControl;
            OnDeviceEvent(gc.ViewModel.DeviceId, gc.ViewModel.Latitude.ToString(), gc.ViewModel.Longitude.ToString(), gc.ViewModel.IsHighlighted);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MockData();
       
        }
    }
    public class DeviceControlViewModel
    {
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
    }
}
