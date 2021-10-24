using SWIM.Models;
using SWIM.Services;
using SWIM.Styles;
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

        private LoginService loginService;

        const int smallWidth = 360;
        const int smallHeight = 740;
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

            loginService = new LoginService();

            DependencyService.Register<IDisplayInfo>();

            InitializeComponent();
            LoadStyles();

            if (!IsUserLoggedIn)
            {
                MainPage = new LoginPage();
            } else
            {
                MainPage = new AppShell();
            }
        }

        void LoadStyles()
        {
            if (IsSmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDeviceStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDeviceStyle.SharedInstance);
            }
        }
        
        private bool IsSmallDevice()
        {
            double screenWidth  = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double screenHeight  = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            return (screenWidth <= smallWidth && screenHeight <= smallHeight);
        }
        

        protected override void OnStart()
        {
            loginService.LoginAutomatically();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
