using System.ComponentModel;
using TransportMasters.ViewModels;
using Xamarin.Forms;

namespace TransportMasters.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}