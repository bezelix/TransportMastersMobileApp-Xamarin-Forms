using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TransportMasters.Models;
using TransportMasters.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    class MarketplaceViewModel : INotifyPropertyChanged
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

        private bool _busy;
        public bool Busy
        {
            get
            {
                return _busy;
            }

            set
            {

                if (_busy != value)
                {
                    _busy = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Busy"));
                    }
                }
            }
        }
  
        public string Email { get; set; }
        public int id { get; set; }

        private MarketplaceService _marketplaceService;

        public event PropertyChangedEventHandler PropertyChanged;

        public MarketplaceViewModel()
        {
            id = Preferences.Get("id", 0); 

            Email = Preferences.Get("e-mail", "Email");
            _marketplaceService = new MarketplaceService();
            VehicleList = new ObservableCollection<Vehicle>();
           
            LoadMarketplacePositions();
            Setup();
        }
        public void LoadMarketplacePositions()
        {
            Busy = true;
            Task.Run(async () =>
            {
                Thread.Sleep(2000);
                VehicleList = await _marketplaceService.GetMarketplacePositions();

                Busy = false;
            });
        }
        CollectionView eventList = new CollectionView();
        
        private void Setup()
        {
            eventList.ItemsSource = VehicleList;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (var evt in VehicleList)
                {
                    var timespan = evt.OfferStartTime.AddHours(24) - DateTime.Now;
                    evt.Timespan = timespan;
                }

                eventList.ItemsSource = null;
                eventList.ItemsSource = VehicleList;

                return true;
            });
        }
    }
}
