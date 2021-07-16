using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportMasters.Models;
using Xamarin.Forms;

namespace TransportMasters.Services
{
    class MarketplaceService : INotifyPropertyChanged
    {
        private ObservableCollection<Vehicle> _vehicleList;
        public ObservableCollection<Vehicle> VehicleList
        {
            get
            {
                return _vehicleList;
            }

            set
            {

                if (_vehicleList != value)
                {
                    _vehicleList = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("VehicleList"));
                    }
                }
            }
        }
        public MarketplaceService()
        {
            VehicleList = new ObservableCollection<Vehicle>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void RefreshDataAsync()
        {
            HttpClient client = new HttpClient();
            var WebAPIUrl = "https://transportmastersapi.azurewebsites.net/api/vehicle/marketplace/vehicle";
            var uri = new Uri(WebAPIUrl);

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<Vehicle>>(content);
                foreach (var item in Items)
                {
                    VehicleList.Add(item);
                }
            }
        }
        public async Task<ObservableCollection<Vehicle>> GetMarketplacePositions()
        {
            RefreshDataAsync();
            return await Task.FromResult(VehicleList);
        }
    }
}
