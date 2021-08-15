using SWIM.Models;
using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SWIM.Services
{
    public class LoginService
    {
        public bool CredentialCheck(string username, string password)
        {
            return username == Constants.Email && password == Constants.Password;
        }

        public async void LoginAutomatically()
        {
            var username = await SecureStorage.GetAsync(Constants.UserKey);
            var password = await SecureStorage.GetAsync(Constants.PwdKey);

            if (App.IsUserLoggedIn)
            {
                await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
            }
            else
            {

                if (!string.IsNullOrEmpty(username) && (!string.IsNullOrEmpty(password)) && CredentialCheck(username, password))
                {
                    App.IsUserLoggedIn = true;
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
                }
                else
                {
                    App.IsUserLoggedIn = false;
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
            }
        }      
    }
}
