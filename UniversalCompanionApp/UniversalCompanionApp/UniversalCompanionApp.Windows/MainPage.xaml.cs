using Microsoft.WindowsAzure.MobileServices;
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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalCompanionApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

         // TestConnection();
        }

        private async void TestConnection()
        {
            ViewModels.ViewModel vm = new ViewModels.ViewModel(App.WachterMobileServiceClient);
            DataContext = vm;
            await vm.GetAllConfigsAsync();
             Config c = new Config();
             c.DeviceId = "Test Device";
             c.FallThreshold = 2.4;
             c.MaxGeoLat = 0;
             c.MaxGeoLng = 0;
             c.MinGeoLat = 0;
             c.MinGeoLng = 0;
             await vm.AddCofigAsync(c);
             await vm.GetAllConfigsAsync();
            
             string a = "";
        }

        private void DeviceControl_OnDeviceEvent(string deviceId, string lat, string lng, bool selected)
        {
            map.SetPin(deviceId, double.Parse(lat), double.Parse(lng), selected);


            monitor.ViewModel = devices.GetMonitorControlViewModel(deviceId);
        }
    }
}
