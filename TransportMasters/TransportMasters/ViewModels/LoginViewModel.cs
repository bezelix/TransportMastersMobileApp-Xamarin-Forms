using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TransportMasters.Models;
using TransportMasters.Views;
using Xamarin.Forms;

namespace TransportMasters.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        //List<string> loginData;
        private async void OnLoginClicked(object obj)
        {
            HttpClient client = new HttpClient();

            Register register = new Register();
            register.Email = "a@a.com";
            register.FirstName = "a@a.com";
            register.LastName = "a@a.com";
            register.Password = "a@a.com";
            register.ConfirmPassword = "a@a.com";
            register.Nationality = "a@a.com";
            register.DateOfBirth = null;


            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://transportmastersapi.azurewebsites.net/api/account/register", content);
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
