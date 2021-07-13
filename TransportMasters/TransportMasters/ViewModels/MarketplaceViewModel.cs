using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TransportMasters.Models;
using TransportMasters.Services;
using Xamarin.Essentials;

namespace TransportMasters.ViewModels
{
    class MarketplaceViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Vehicle> _vehicleList;
        public ObservableCollection<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; OnPropertyChanged(); }
        }
        private bool _busy;
        public bool Busy
        {
            get { return _busy; }
            set { _busy = value; OnPropertyChanged(); }
        }


        public string Email { get; set; }

        private MarketplaceService _marketplaceService;

        public MarketplaceViewModel()
        {
            Title = "Marketplace";
            Email = Preferences.Get("e-mail", "Email");
            _marketplaceService = new MarketplaceService();
            VehicleList = new ObservableCollection<Vehicle>();
            LoadMarketplacePositions();
        }
        public void LoadMarketplacePositions()
        {
            Busy = true;
            Task.Run(async () =>
            {
                VehicleList = await _marketplaceService.GetMarketplacePositions();
                Busy = false;
            });
        }
    }
}
