using SWIM.Models;
using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email, password, 
                       errorMessage = "You have entered incorrect email or password";
        private bool isVisible;
        private User user = new User();

        public ICommand LoginCommand { get; }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    //SetProperty(ref _email, value);
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value) 
                {
                    password = value;
                    //SetProperty(ref _password, value);
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (errorMessage != null)
                {
                    errorMessage = value;
                    SetProperty(ref errorMessage, value);
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked()
        {

            user.Email = email;
            user.Password = password;

            var isValid = CredentialCheck(user);

            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");

            }
            else
            {
                isVisible = true;
            }
        }

        private bool CredentialCheck(User user)
        {
            return user.Email == Constants.Email && user.Password == Constants.Passwword;
        }
    }
}
