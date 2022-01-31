﻿using Quick.Xamarin.BLE.Abstractions;
using Smart_bike_G3.Repositories;
using Smart_bike_G3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Regular.ttf", Alias = "Rubik-regular")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Bold.ttf", Alias = "Rubik-Bold")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-SemiBold.ttf", Alias = "Rubik-SemiBold")]

namespace Smart_bike_G3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsVideo : ContentPage
    {

        public ResultsVideo()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                InitializeComponent();
                //btnScorebord.Clicked += BtnScorebord_Clicked;
                //showKilometers();
                btnHome.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Home.png");
                btnOpnieuw.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Again.png");
                ImgLeft.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.BackgroundScore2.png");
                ImgRight.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.BackgroundScore1.png");
            }
            else
            {
                Navigation.PushAsync(new NoNetworkPage());
            }
        }

        protected override void OnAppearing()
        {

            if (Bluetooth.BleStatus != AdapterConnectStatus.Connected)
            {
                Navigation.PushAsync(new NoSensorPage());
            }
            base.OnAppearing();
        }

        private async void showKilometers()
        {

            //int kilometers = 12;
            //string kilometerString = $"{kilometers}km";
            //lblKilometers.Text = kilometerString;

            // await Repository.AddResultsVideo(1, "test", kilometers);
        }

        private void BtnScorebord_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Scorebord(-1));
        }

    }
}
