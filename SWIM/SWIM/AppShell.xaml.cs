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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(BillsPage), typeof(BillsPage));
            Routing.RegisterRoute(nameof(UsagePage), typeof(UsagePage));
            Routing.RegisterRoute(nameof(HelpAndSupportPage), typeof(HelpAndSupportPage));
            Routing.RegisterRoute(nameof(MorePage), typeof(MorePage));


        }

    }
}
