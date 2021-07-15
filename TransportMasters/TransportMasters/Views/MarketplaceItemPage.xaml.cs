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