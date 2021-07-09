using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using TransportMasters.Models;
using Xamarin.Essentials;

namespace TransportMasters.ViewModels
{
    class MarketplaceViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Vehicle> VehicleList { get; set; }
        public string Email { get; set; }
        public MarketplaceViewModel()
        {
            Title = "Marketplace";
            Email = Preferences.Get("e-mail", "Email");

            VehicleList = new ObservableCollection<Vehicle>();
            //VehicleList.Add(new Vehicle { ModelName = "Test1", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            
            RefreshDataAsync(Email);

        }

        private async void RefreshDataAsync(string _email)
        {
            HttpClient client = new HttpClient();
            var WebAPIUrl = "https://transportmastersapi.azurewebsites.net/api/account/GetUserByEmail/" + Email;
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var Item = JsonConvert.DeserializeObject<Register>(content);
                    
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
