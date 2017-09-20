using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            }
          
            catch (Exception ex)
            {
                //will catch any general exception and set message in a string
                txtLat.Text = ex.Message;
            }

        }
    }
}
