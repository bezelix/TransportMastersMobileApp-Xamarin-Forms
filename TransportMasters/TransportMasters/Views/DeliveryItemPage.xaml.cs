using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverItemPage : ContentPage
    {
        public DriverItemPage(string Name, string Ingredients, string source)
        {
            InitializeComponent();
            MyItemNameShow.Text = Name;
            MyIngrediantItemShow.Text = Ingredients;
            MyImageCall.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}