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
        DateTime dateTime;
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }

            set
            {

                if (dateTime != value)
                {
                    dateTime = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
        }

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
        private ObservableCollection<Vehicle> _viewList;
        public ObservableCollection<Vehicle> ViewList
        {
            get
            {
                return _viewList;
            }
            set
            {

                if (_viewList != value)
                {
                    _viewList = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ViewList"));
                    }
                }
                else
                {
                    _viewList = value;
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
        string _vehicleListDateTime;
        public string VehicleListDateTime
        {
            get
            {
                return _vehicleListDateTime;
            }

            set
            {
                if (_vehicleListDateTime != value)
                {
                    _vehicleListDateTime = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("VehicleListDateTime"));
                    }
                }
            }
        }
        public string Email { get; set; }

        private MarketplaceService _marketplaceService;

        public event PropertyChangedEventHandler PropertyChanged;

        public MarketplaceViewModel()
        {
            Email = Preferences.Get("e-mail", "Email");
            _marketplaceService = new MarketplaceService();
            VehicleList = new ObservableCollection<Vehicle>();
            ViewList = new ObservableCollection<Vehicle>();
           
            LoadMarketplacePositions();
            Setup();
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                
                foreach (var item in VehicleList)
                {
                    if (VehicleList.Count > 0)
                    {
                        if (ViewList.Contains(item))
                        {
                            var _object = ViewList.FirstOrDefault(i => i.Id == item.Id);
                            var _offerStartTime = _object.OfferStartTime.AddHours(24);
                            _object.Timespan = _offerStartTime - DateTime.Now;
                            _object.TimespanString = _object.Timespan.ToString();

                        }
                        else
                        {
                            ViewList.Add(item);
                        }
                    }
                }
                return true;
            });

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
