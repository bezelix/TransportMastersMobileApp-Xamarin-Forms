using System;
using System.Collections.Generic;
using System.ComponentModel;
using TransportMasters.Models;
using TransportMasters.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransportMasters.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}