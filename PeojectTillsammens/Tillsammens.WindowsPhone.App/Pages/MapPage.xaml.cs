using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using AutoMapper.QueryableExtensions.Impl;
using Tillsammens.WindowsPhone.App.ViewModel;

namespace Tillsammens.WindowsPhone.App.Pages
{
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
        }
        private MapViewModel ViewModel
        {
            get { return DataContext as MapViewModel; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            ViewModel.LoadCmd.Execute(e.Parameter);
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            ViewModel.GoBack();
            e.Handled = true;
        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            var myBasic = new BasicGeoposition
            {
                Altitude = 0,
                Latitude = 50.2915127,
                Longitude = 18.6685934
            };
            //double.Parse(ViewModel.Friend.X);
            //double.Parse(ViewModel.Friend.Y);

            //var myGeoPoint = new Geopoint(myBasic);
            //MapControl.Center = myGeoPoint;
            //MapControl.ZoomLevel = 15;

            //var mapIcon = new MapIcon();
            //var mapSth = new MapPolygon();
            //var imag = new Image();
            //imag.Source = new BitmapImage(new Uri(ViewModel.Friend.PhotoUri,UriKind.Absolute));
            //imag.Width = 50;
            //imag.Height = 50;
            //var file = imag as FileRandomAccessStream;
            //mapIcon.Image = RandomAccessStreamReference.CreateFromFile(imag.Source); ;
            
            
           

            //mapIcon.NormalizedAnchorPoint = new Point(0.25, 0.9);
            //mapIcon.Location = myGeoPoint;
            //mapIcon.Title = ViewModel.Friend.Login;
            //MapControl.MapElements.Add(mapIcon);
            //MapControl.Center = myGeoPoint;
            //MapControl.ZoomLevel = 15;
        }

        private void MapControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
