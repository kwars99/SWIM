using SWIM.Services;
using SWIM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            } else
            {
                MainPage = new NavigationPage(new SWIM.Views.DashBoard());
            }
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
