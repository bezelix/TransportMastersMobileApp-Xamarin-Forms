using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMasters.Models;
using TransportMasters.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehiclesPage : ContentPage
    {
        public VehiclesPage()
        {
            InitializeComponent();
            BindingContext = new VehicleViewModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            //var mydetails = e.Item as Vehicle;
            //await Navigation.PushAsync(new VehicleItemPage(mydetails.Name, mydetails.Ingredients, mydetails.Image));

        }
    }
}