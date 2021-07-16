using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using TransportMasters.Models;

namespace TransportMasters.ViewModels
{
    public class MarketplaceItemPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MarketplaceItemPageViewModel()
        {

        }
        public MarketplaceItemPageViewModel(Vehicle vehicle)
        {
            string ModelName = vehicle.ModelName;
            string CarManufacturer = vehicle.CarManufacturer;
            string Title = vehicle.CarManufacturer + " " + vehicle.ModelName;
            string ManufactureDate = vehicle.ManufactureDate.ToString();
            string Payload = vehicle.Payload.ToString();
            string Speed = vehicle.Speed.ToString();
            string CarCondition = vehicle.CarCondition.ToString();
            string Value = vehicle.StartPrice.ToString();
            //RefreshDataAsync(vehicle.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
