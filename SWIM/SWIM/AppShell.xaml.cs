using SWIM.ViewModels;
using SWIM.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SWIM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
