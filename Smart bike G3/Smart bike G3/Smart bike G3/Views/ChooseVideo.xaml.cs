﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Regular.ttf", Alias = "Rubik-Regular")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Bold.ttf", Alias = "Rubik-Bold")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-SemiBold.ttf", Alias = "Rubik-SemiBold")]

namespace Smart_bike_G3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseVideo : ContentPage
    {

        public static string Listening;
        public ChooseVideo()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                InitializeComponent();
                AddEvents();
                MakeResponsive();
            }
            else
            {
                Navigation.PushAsync(new NoNetworkPage());
            }
            
        }

        private void MakeResponsive()
        {
            // aanpassen aan grote van scherm

            var width = Application.Current.MainPage.Width;
            var height = Application.Current.MainPage.Height;
            Console.WriteLine(width + "x" + height);
            
            //AbsLayBook.Scale =
        }

        private void AddEvents()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += AbsLayBack_Tabbed;
            AbsLayBack.GestureRecognizers.Add(tapGestureRecognizer);

            TapGestureRecognizer tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += AbsLayMusic_Tabbed;
            AbsLayMusic.GestureRecognizers.Add(tapGestureRecognizer2);

            TapGestureRecognizer tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += AbsLayBook_Tabbed;
            AbsLayBook.GestureRecognizers.Add(tapGestureRecognizer3);
        }

        private void AbsLayBook_Tabbed(object sender, EventArgs e)
        {
            AbsLayBook.Scale = 8;
            Listening = "luisterboek";
            Console.WriteLine("Tabbed luisterboek");
            Navigation.PushAsync(new VideoPage());
        }

        

        private void AbsLayMusic_Tabbed(object sender, EventArgs e)
        {
            AbsLayBook.Scale = 8;
            Listening = "muziek";
            Console.WriteLine("Tabbed music");
            Navigation.PushAsync(new VideoPage());
            //Kind meegeven met de game
            //wordt terug opgehaald in scorebord
        }

        private void AbsLayBack_Tabbed(object sender, EventArgs e)
        {
            AbsLayBack.Scale = 1.5;
            Navigation.PopAsync();
        }
    }
}
