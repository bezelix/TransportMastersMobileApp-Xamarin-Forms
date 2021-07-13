using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMasters.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarketplaceItemPage : ContentPage
    {
        public MarketplaceItemPage(Vehicle vehicle)
        {
            InitializeComponent();

            ModelName.Text = vehicle.ModelName;
            CarManufacturer.Text = vehicle.CarManufacturer;
            CarManufacturer.Text = vehicle.ManufactureDate.ToString();
            CarManufacturer.Text = vehicle.Payload.ToString();
            CarManufacturer.Text = vehicle.Speed.ToString();
            CarManufacturer.Text = vehicle.CarCondition.ToString();
        }
    }
}
//public int Id { get; set; }
//public string ModelName { get; set; }
//public string CarManufacturer { get; set; }
//public DateTime ManufactureDate { get; set; }
//public float Payload { get; set; }
//public float Speed { get; set; }
//public float StartPrice { get; set; }
//public int CarCondition { get; set; }
//public string Lat { get; set; }
//public string Lon { get; set; }
//public int Driver { get; set; }
//public int Cargo { get; set; }
//public bool OnMarket { get; set; }