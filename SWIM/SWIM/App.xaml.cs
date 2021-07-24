﻿using SWIM.Services;
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

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDc4ODkyQDMxMzkyZTMyMmUzMGtSWmFjN1ptS1NwOU5FQXBtQUY0MlNYMy9BaXR0SmlZaDI5cGZhL3lYcXM9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
