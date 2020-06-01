using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.ComponentModel;
using Windows.Devices.Geolocation;

// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinUILibrary
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocationBlock : UserControl, INotifyPropertyChanged
    {
        public LocationBlock()
        {
            this.InitializeComponent();
            PropertyChanged += (s, e) => { };
            Loaded += async (s, e) =>
            {
                var access = await Geolocator.RequestAccessAsync();
                if (access == GeolocationAccessStatus.Allowed)
                {
                    Location = Geolocator.DefaultGeoposition.ToString();
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseEvent(string name) => PropertyChanged(this, new PropertyChangedEventArgs(name));

        private string _location;
        public string Location
        {
            get => _location;
            set
            {
                if (value != _location)
                {
                    _location = value;
                    RaiseEvent(nameof(Location));
                }
            }
        }
    }
}
