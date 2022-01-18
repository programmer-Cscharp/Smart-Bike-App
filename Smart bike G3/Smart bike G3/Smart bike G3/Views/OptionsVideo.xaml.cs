﻿using Newtonsoft.Json;
using Smart_bike_G3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Regular.ttf", Alias = "Rubik-Regular")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Bold.ttf", Alias = "Rubik-Bold")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-SemiBold.ttf", Alias = "Rubik-SemiBold")]

namespace Smart_bike_G3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsVideo : ContentPage
    {

        public static int VideoId;
        public OptionsVideo()
        {
            InitializeComponent();

            Loadpictures();
            PlayImage();

            imgbtnFirst.Clicked += BtnFirst_Clicked;
            imgbtnSecond.Clicked += BtnSecond_Clicked;
            imgbtnThird.Clicked += BtnThird_Clicked;
            imgbtnFourth.Clicked += BtnFourth_Clicked;
            
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += AbsLayBack_Tabbed;
            AbsLayBack.GestureRecognizers.Add(tapGestureRecognizer);

            //btnSettings.Clicked += BtnSettings_Clicked;

            TapGestureRecognizer tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += AbsLaSetting_Tabbed;
            AbsLaySettings.GestureRecognizers.Add(tapGestureRecognizer1);

        }

        private void PlayImage()
        {
            ImgPlay.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Asset2.png");
            ImgPlay1.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Asset2.png");
            ImgPlay2.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Asset2.png");
            ImgPlay3.Source = ImageSource.FromResource(@"Smart_bike_G3.Assets.Asset2.png");
        }

        private async void AbsLaSetting_Tabbed(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Geef de code", "pincode", maxLength: 4, keyboard: Keyboard.Numeric);
            if (result != null)
            {
                if (Int32.Parse(result) == 8000)
                {
                    Debug.WriteLine("oké");
                    await Navigation.PushAsync(new VideoAdminPage());
                }
                else
                {
                    await DisplayAlert("Foutieve code", "", "OK");

                }
            }
        }

        private void Loadpictures()
        {
            int videoId = OptionsVideo.VideoId;
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "videoUrls.txt");
            List<VideoSettings> settings = JsonConvert.DeserializeObject<List<VideoSettings>>(File.ReadAllText(fileName));
            List<string> urls = new List<string>();

            foreach (var i in settings)
            {
                urls.Add(i.vid.Url);
            }
            setThumbnail(urls[0], imgbtnFirst);
            setThumbnail(urls[1], imgbtnSecond);
            setThumbnail(urls[2], imgbtnThird);
            setThumbnail(urls[3], imgbtnFourth);
        }
        private void setThumbnail(string url,ImageButton btn) { 
            string vidId = url.Split('=')[1].Split('?')[0].Split('&')[0];
            if (RemoteFileExists($"https://img.youtube.com/vi/{vidId}/maxresdefault.jpg"))
            {
                btn.Source = $"https://img.youtube.com/vi/{vidId}/maxresdefault.jpg";
            }
            else
            {
                btn.Source = $"https://img.youtube.com/vi/{vidId}/hqdefault.jpg";

            }
            Debug.Write(btn.Source);


            
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }



        private void BtnFourth_Clicked(object sender, EventArgs e)
        {
            
            VideoId = 4;
            Navigation.PushAsync(new VideoExplanation());
        }

        private void BtnThird_Clicked(object sender, EventArgs e)
        {
            VideoId= 3;
            Navigation.PushAsync(new VideoExplanation());
        }

        private void BtnSecond_Clicked(object sender, EventArgs e)
        {
            VideoId = 2;
            Navigation.PushAsync(new VideoExplanation());
        }

        private void BtnFirst_Clicked(object sender, EventArgs e)
        {
            VideoId = 1;
            Navigation.PushAsync(new VideoExplanation());
        }

        private void AbsLayBack_Tabbed(object sender, EventArgs e)
        {
            AbsLayBack.Scale = 1.5;
            Navigation.PopAsync();
        }
    }
}