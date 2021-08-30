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
            Routing.RegisterRoute(nameof(BillsPage), typeof(BillsPage));
            Routing.RegisterRoute(nameof(UsagePage), typeof(UsagePage));
            Routing.RegisterRoute(nameof(HelpAndSupportPage), typeof(HelpAndSupportPage));
            Routing.RegisterRoute(nameof(MorePage), typeof(MorePage));
            Routing.RegisterRoute(nameof(PaymentExtensionPage), typeof(PaymentExtensionPage));
        }

    }
}
