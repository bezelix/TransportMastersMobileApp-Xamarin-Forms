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
    public partial class DriversPage : ContentPage
    {
        public DriversPage()
        {
            InitializeComponent();
            BindingContext = new DriversVievModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as DriverModel;
            await Navigation.PushAsync(new DriverItemPage(mydetails.Name, mydetails.Ingredients, mydetails.Image));

        }
    }
}