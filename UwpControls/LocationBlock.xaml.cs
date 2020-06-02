using System;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Geolocation;
using System.ComponentModel;
using System.Linq;

// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpControls
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
                    var locator = new Geolocator();
                    var location = await locator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
                    var coordinates = location.Coordinate.Point.Position;
                    Location = $"{coordinates.Latitude} {coordinates.Longitude}";
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
