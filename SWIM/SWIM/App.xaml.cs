using SWIM.Models;
using SWIM.Services;
using SWIM.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        static DatabaseService database;

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(Path.Combine(FileSystem.AppDataDirectory, "data.db"));
                }
                return database;
            }
        }

        public App()
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.APIKey);

            InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new LoginPage();
            } else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnStart()
        {
            LoginAutomatically();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async void LoginAutomatically()
        {
            var loginService = new LoginService();
            var username = await SecureStorage.GetAsync(Constants.UserKey);
            var password = await SecureStorage.GetAsync(Constants.PwdKey);

            if (loginService.CredentialCheck(username, password))
            {
                IsUserLoggedIn = true;
                MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
            }
            else
            {
                IsUserLoggedIn = false;
                MainPage = new LoginPage();
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}
