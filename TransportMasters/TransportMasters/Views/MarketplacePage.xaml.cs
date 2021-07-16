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
    public partial class MarketplacePage : ContentPage
    {
        public MarketplacePage()
        {
            InitializeComponent();
            BindingContext = new MarketplaceViewModel();
        }
        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var mydetails = e.CurrentSelection.FirstOrDefault() as Vehicle;
            await Navigation.PushAsync(new MarketplaceItemPage(mydetails));
        }
    }
}