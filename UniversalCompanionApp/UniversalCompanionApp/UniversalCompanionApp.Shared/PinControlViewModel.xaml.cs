using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class PinControlViewModel : UserControl, INotifyPropertyChanged
    {
       public PinControlViewModel()
        {
            this.InitializeComponent();
        }
       private bool _IsSelected;
        public bool IsSelected
       {
           get
           {
               return _IsSelected;
           }
           set
           {
               _IsSelected = value;
               PropertyChanged(this, new PropertyChangedEventArgs("PhilHartman"));
           }
       }
        public Brush PhilHartman
        {
            get
            {
                return _IsSelected ? new SolidColorBrush(Colors.Yellow) : new SolidColorBrush(Colors.DarkBlue);
            }
        }
        public string DeviceId { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
