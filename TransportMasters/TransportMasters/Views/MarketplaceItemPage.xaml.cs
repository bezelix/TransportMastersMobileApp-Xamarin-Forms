using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransportMasters.Models;
using TransportMasters.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarketplaceItemPage : ContentPage, INotifyPropertyChanged
    {
        Vehicle _vehicle;
        private int id;

        public MarketplaceItemPage(Vehicle vehicle)
        {
            _vehicle = vehicle;
            id = Preferences.Get("id", 0);
            InitializeComponent();
            Setup(vehicle);
            this.BindingContext = new MarketplaceItemPageViewModel(vehicle);
            //ModelName.Text = vehicle.ModelName;
            //CarManufacturer.Text = vehicle.CarManufacturer;
            Title = vehicle.CarManufacturer + " " + vehicle.ModelName;
            ManufactureDate.Text = vehicle.ManufactureDate.ToString("dd-MM-yyyy");
            Payload.Text = vehicle.Payload.ToString() + "Kg";
            Speed.Text = vehicle.Speed.ToString() + "Km/h";
            CarCondition.Text = vehicle.CarCondition.ToString() + "%";
            StartPrice.Text = vehicle.StartPrice.ToString() + "$";
            Bid.Text = vehicle.StartPrice + 1.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Setup(Vehicle vehicle)
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                var timespan = vehicle.OfferStartTime.AddHours(24) - DateTime.Now;
                vehicle.Timespan = timespan;
                Days.Text = vehicle.Timespan.Days.ToString();
                Hours.Text = vehicle.Timespan.Hours.ToString();
                Minutes.Text = vehicle.Timespan.Minutes.ToString();
                Seconds.Text = vehicle.Timespan.Seconds.ToString();
                return true;
            });
        }
        public async void AddBid_OnClicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            Bid _object = new Bid();
            if (id != 0)
            {
                _object.UserIdentyficator = id;
                _object.VehicleIdentyficator = _vehicle.Id;
                string value = Bid.Text.ToString();
                _object.BidValue = long.Parse(value);
                _object.Date = DateTime.Now;

                StringContent content = new StringContent(JsonConvert.SerializeObject(_object), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://transportmastersapi.azurewebsites.net/api/marketplace/addBid", content);
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    //await DisplayAlert("Failed", , "OK");
                }
            }
        }
    }
}