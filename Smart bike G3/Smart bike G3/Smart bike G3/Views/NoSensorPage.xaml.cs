﻿using System;
using Xamarin.Forms;
using TestBluethoot.Services;
using Smart_bike_G3.Services;
using Xamarin.Essentials;

[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Regular.ttf", Alias = "Rubik-regular")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-Bold.ttf", Alias = "Rubik-Bold")]
[assembly: ExportFont(@"Smart_bike_G3.Fonts.Rubik-SemiBold.ttf", Alias = "Rubik-SemiBold")]

namespace Smart_bike_G3.Views
{
    public partial class NoSensorPage : ContentPage
    {
        public NoSensorPage()
        {
            InitializeComponent();

            //prevent sleepmode
            
            DeviceDisplay.KeepScreenOn = false;
            Device.StartTimer(TimeSpan.FromMilliseconds(10000), ShowButtn);

            Sensor.Start();
            Bluetooth.ClearAllDelegatesOfLostConnection();
            
            Bluetooth.MadeConnection += ((s, e) =>
            {
                //List<Page> pages = (List<Page>)Navigation.NavigationStack;
                //foreach (Page page in pages)
                //{
                //    Navigation.RemovePage(page);
                //}

               
               
                Navigation.PushAsync(new VideoOrGame());
                //Navigation.PopToRootAsync();
                //Navigation.PopAsync();
                //Bluetooth.LostConnection += ((se, ev) =>
                //{

                //    Navigation.PushAsync(new NoSensorPage());

                //});

            });
        }

        private bool ShowButtn()
        {
            zoekBtn.IsVisible = true;
            return false;
        }



        //private void Scan()
        //{
        //    Thread thread = new Thread(() => {
        //        ObservableCollection<BleList> blelist = Bluetooth.Scan();
        //        //pk.ItemsSource = Bluetooth.Scan();
        //        if (blelist.Count == 0) Debug.WriteLine("Looking for blelist...");
        //        blelist.CollectionChanged += ConnectSensor;
        //    });
        //    thread.Start();
        //}

        //private void ConnectSensor(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if(e.NewItems != null) {
        //    if (e.NewItems.Cast<BleList>().Any(x => x.Name == "46003-81"))
        //    {
        //        Bluetooth.Connect((BleList)e.NewItems.Cast<BleList>().Where(x => x.Name == "46003-81").First());
        //        ObservableCollection<CharacteristicsList> listChar = Bluetooth.GetCharacteristics();

        //        listChar.CollectionChanged += NotifySpeed;
        //    }
        //    }

        //}

        //private void NotifySpeed(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (!Bluetooth.isnotify)
        //    {
        //        if (e.NewItems.Cast<CharacteristicsList>().Any(x => x.Uuid == "00002a5b-0000-1000-8000-00805f9b34fb"))
        //        {
        //            Bluetooth.Select_Characteristic(Bluetooth.GetCharacteristics().Where(x => x.Uuid == "00002a5b-0000-1000-8000-00805f9b34fb").First());

        //            Bluetooth.NewData += Sensor.GotNewdata;
        //            Sensor.NewDataCadence += changeLabel;

        //            Bluetooth.Notify();
        //        }

        //    }
        //}


        //private void changeLabel(object sender, int e)
        //{
        //    Debug.WriteLine(e.ToString() + " rpm");
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Search());
        }
    }
}
