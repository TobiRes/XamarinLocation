using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;

namespace Location
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnGetLocation.Clicked += BtnGetLocation_Clicked;
        }

        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();
        }
        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            try{
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                txtLat.Text = "Breitengrad: " + position.Latitude.ToString();
                txtLong.Text = "Längengrad: " + position.Longitude.ToString();
                TestMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(1)));
            }

            catch (Exception ex)
            {
                //Falls was schiefläuft, z.B. kein GPS aktiviert
                txtLat.Text = ex.Message;
            }

            
        }
    }
}
