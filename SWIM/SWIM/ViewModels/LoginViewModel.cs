using SWIM.Models;
using SWIM.Services;
using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginService loginService;

        private string email, password, 
                       errorMessage = "You have entered incorrect email or password";

        private bool isVisible, rememberMe;

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
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
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

        public bool RememberMe
        {
            get
            {
                return rememberMe;
            }
            set
            {
                if (rememberMe != value)
                {
                    rememberMe = value;
                    OnPropertyChanged(nameof(RememberMe));
                }
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            loginService =  new LoginService();
        }

        private async void OnLoginClicked()
        {
            user.Email = email;
            user.Password = password;

            var isValid = loginService.CredentialCheck(user.Email, user.Password);

            if (isValid)
            {
                
                if (RememberMe)
                {
                    try
                    {
                        await SecureStorage.SetAsync(Constants.UserKey, user.Email);
                        await SecureStorage.SetAsync(Constants.PwdKey, user.Password);
                    }
                    catch (Exception ex)
                    {
                        // Possible that device doesn't support secure storage on device.
                    }        
                }
                else
                {
                    SecureStorage.Remove(Constants.UserKey);
                    SecureStorage.Remove(Constants.PwdKey);
                }
                
                App.IsUserLoggedIn = true;
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");

            }
            else
            {
                IsVisible = true;
                Email = "";
                Password = "";
            }
        }
    }
}
