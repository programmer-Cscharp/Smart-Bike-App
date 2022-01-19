﻿using Smart_bike_G3.Views;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smart_bike_G3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            firstTimefileSetup();
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });
            MainPage = new NavigationPage(new Name());
        }

        private void firstTimefileSetup() //Makes file for videoUrls if non exist
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "videoUrls.txt");
            if (!File.Exists(fileName))
            {
                Debug.WriteLine("Creating url storage");
                string vidUrls = "[{\"video\":{\"url\":\"https://www.youtube.com/watch?v=07d2dXHYb94&t=1s}\",\"audio\":0}},{\"video\":{\"url\":\"https://www.youtube.com/watch?v=07d2dXHYb94&t=1s}\",\"audio\":0}},{\"video\":{\"url\":\"https://www.youtube.com/watch?v=07d2dXHYb94&t=1s}\",\"audio\":1}},{\"video\":{\"url\":\"https://www.youtube.com/watch?v=07d2dXHYb94&t=1s}\",\"audio\":1}}]";
                File.WriteAllText(fileName, vidUrls);
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            //MainPage = new NavigationPage(new Name());
        }
    }
}
