using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransportMasters.Models;
using TransportMasters.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TransportMasters.ViewModels
{
    public class AboutViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Command AboutCommandOnDeliveriesClicked { get; }

        public string Email { get; set; }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                }
            }
        }
        private string _accountBalance;
        public string AccountBalance
        {
            get => _accountBalance;
            set
            {
                if (value != _accountBalance)
                {
                    _accountBalance = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(AccountBalance)));
                }
            }
        }
        private string _lvl;
        public string Lvl
        {
            get => _lvl;
            set
            {
                if (value != _lvl)
                {
                    _lvl = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Lvl)));
                }
            }
        }
        private string _PremiumPoints;
        public string PremiumPoints
        {
            get => _PremiumPoints;
            set
            {
                if (value != _PremiumPoints)
                {
                    _PremiumPoints = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PremiumPoints)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public AboutViewModel()
        {
            Title = "Main Page";
            Preferences.Set("e-mail", "tomasz@dupski.com");
            Email = Preferences.Get("e-mail", "Email");
            RefreshDataAsync(Email);
        }
        private async void RefreshDataAsync(string _email)
        {
            HttpClient client = new HttpClient();
            var WebAPIUrl = "https://transportmastersapi.azurewebsites.net/api/account/GetUserByEmail/" + Email;
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var Item = JsonConvert.DeserializeObject<Register>(content);
                    FirstName = Item.FirstName;
                    AccountBalance = Item.AccountBalance.ToString();
                    Lvl= Item.Level.ToString();
                    PremiumPoints = Item.PremiumPoints.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}