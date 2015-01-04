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
    public sealed partial class PinControl : UserControl
    {
        private PinControlViewModel _ViewModel;
        public PinControl(PinControlViewModel viewModel)
        {

            this.InitializeComponent();
            ViewModel = viewModel;
        }
        public PinControlViewModel ViewModel
        {
            get
            {
                return _ViewModel;
            }
            set
            {
                _ViewModel = value;
                DataContext = _ViewModel;
            }
        }
    }
}
