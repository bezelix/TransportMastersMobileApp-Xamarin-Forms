using System;
using System.ComponentModel;
using TransportMasters.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public string UserName { get; set; }
        public AboutPage()
        {
            InitializeComponent();
            this.BindingContext = new AboutViewModel();
        }
        private async void DeliveriesButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeliveriesPage());
        }
        private async void DriversButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriversPage());
        }
        private async void MessagesButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriversPage());
        }
        private async void VehiclesButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VehiclesPage());
        }
    }
}