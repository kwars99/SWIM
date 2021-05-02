using SWIM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = new Models.User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = CredentialCheck(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool CredentialCheck(Models.User user)
        {
            return user.Email == Models.Constants.Email && user.Password == Models.Constants.Passwword;
        }
    }
}