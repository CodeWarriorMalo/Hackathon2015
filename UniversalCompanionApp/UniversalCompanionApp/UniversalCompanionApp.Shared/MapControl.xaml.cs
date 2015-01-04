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
    public sealed partial class MapControl : UserControl
    {
        public MapControl()
        {
            this.InitializeComponent();
        }
        List<PinControl> _Pins = new List<PinControl>();
        public void SetPin(string deviceId, double lat, double lng, bool selected)
        {
           if(_Pins.Any(p=>p.ViewModel.DeviceId == deviceId))
           {
             //  _Pins.Find(p => p.ViewModel.DeviceId == deviceId).SetValue(Canvas.LeftProperty, ConvertLng(lng));
             //  _Pins.Find(p => p.ViewModel.DeviceId == deviceId).SetValue(Canvas.TopProperty, ConvertLat(lat));
               }
           else
           {
               _Pins.Add(new PinControl(new PinControlViewModel() { DeviceId = deviceId }));
               _Pins.Find(p => p.ViewModel.DeviceId == deviceId).SetValue(Canvas.LeftProperty, ConvertLng(lng));
               _Pins.Find(p => p.ViewModel.DeviceId == deviceId).SetValue(Canvas.TopProperty, ConvertLat(lat));
               pinCanvas.Children.Add(_Pins.Find(p => p.ViewModel.DeviceId == deviceId));
           }
           foreach (var pin in _Pins)
               pin.ViewModel.IsSelected = false;
           _Pins.Find(p => p.ViewModel.DeviceId == deviceId).ViewModel.IsSelected = selected;
        }
        private Random _Rnd = new Random();
        private float ConvertLng(double lng)
        {
            float l = (float)(lng/(double)2);
            if (l < 0) l *= -1;
            #if WINDOWS_PHONE_APP
            int deviate = _Rnd.Next(50);
#else
            int deviate = _Rnd.Next(300);
#endif
            return deviate + l;
        }
        private float ConvertLat(double lat)
        {
            float l = (float)(lat / (double)2);
#if WINDOWS_PHONE_APP
            int deviate = _Rnd.Next(50);
#else
            int deviate = _Rnd.Next(300);
#endif
            return deviate + l;
        }
    }
}
