using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace UniversalCompanionApp
{
    public delegate void ControlSelectedEventHandler(UserControl control);
    interface ISelectable
    {
        event ControlSelectedEventHandler OnSelected;
    }
}
