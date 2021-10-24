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
            Routing.RegisterRoute(nameof(PdfPage), typeof(PdfPage));
            Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(PaymentExtensionPage), typeof(PaymentExtensionPage));
            Routing.RegisterRoute(nameof(OutagePage), typeof(OutagePage));
            Routing.RegisterRoute(nameof(HowToReadBillPage), typeof(HowToReadBillPage));
            Routing.RegisterRoute(nameof(MyAccountPage), typeof(MyAccountPage));
            Routing.RegisterRoute(nameof(EditDetailsPage), typeof(EditDetailsPage));
            Routing.RegisterRoute(nameof(ReportUsagePage), typeof(ReportUsagePage));

        }

    }
}
