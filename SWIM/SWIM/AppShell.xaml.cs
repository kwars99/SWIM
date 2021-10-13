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
            Routing.RegisterRoute(nameof(PdfPage), typeof(PdfPage));
            Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(PaymentExtensionPage), typeof(PaymentExtensionPage));
            Routing.RegisterRoute(nameof(OutagePage), typeof(OutagePage));
            Routing.RegisterRoute(nameof(BillingPreferencesPage), typeof(BillingPreferencesPage));
            Routing.RegisterRoute(nameof(HowToReadBillPage), typeof(HowToReadBillPage));
        }

    }
}
