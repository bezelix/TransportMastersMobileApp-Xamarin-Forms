using System;
using System.Collections.Generic;
using TransportMasters.ViewModels;
using TransportMasters.Views;
using Xamarin.Forms;

namespace TransportMasters
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
