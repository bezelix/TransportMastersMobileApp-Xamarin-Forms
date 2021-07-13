using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportMasters.Models;

namespace TransportMasters.Services
{
    class MarketplaceService
    {
        public ObservableCollection<Vehicle> VehicleList { get; set; }
        public MarketplaceService()
        {
            VehicleList = new ObservableCollection<Vehicle>();
            //RefreshDataAsync();
        }

        private async void RefreshDataAsync()
        {
            HttpClient client = new HttpClient();
            var WebAPIUrl = "https://transportmastersapi.azurewebsites.net/api/vehicle/marketplace/vehicle";
            var uri = new Uri(WebAPIUrl);

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                //VehicleList.Clear();
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<Vehicle>>(content);
                foreach (var item in Items)
                {
                    VehicleList.Add(item);
                }
            }
            else
            {

            }

        }
        public async Task<ObservableCollection<Vehicle>> GetMarketplacePositions()
        {
            RefreshDataAsync();
            Thread.Sleep(4000);
            return await Task.FromResult(VehicleList);
        }
    }
}
