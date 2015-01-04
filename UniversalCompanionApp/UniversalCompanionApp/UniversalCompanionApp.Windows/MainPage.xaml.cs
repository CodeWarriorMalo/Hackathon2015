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
            TestConnection();
        }

        private async void TestConnection()
        {
            IMobileServiceTable<RawData> _RawTable = App.WachterMobileServiceClient.GetTable<RawData>();
            
      
          //  await _RawTable.InsertAsync(new RawData() { AccelX = 3, AccelY = 4, AccelZ = 5, DeviceId = "Test", GeoLat = 1, GeoLng = 2, TimeStamp = DateTime.Now });
            var _RawItems = await _RawTable.ReadAsync();

            string a = "";
        }
    }
}
