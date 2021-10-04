using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpAndSupportPage : ContentPage
    {
        public HelpAndSupportPage()
        {
            InitializeComponent();
        }

        //Button to navigate to Outage Page
        private async void OutageButton_Clicked(object sender, EventArgs e)
        {
            var route = $"{nameof(OutagePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void SubEnqPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnquiriesPage());
        }

        private async void SubmitEnqButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(description.Text))
            {
                DateTime currentDate = DateTime.Now;
                await App.Database.InsertEnquiryAsync(new Models.Enquiry()
                {
                    Cateogry = "General",
                    Text = description.Text,
                    EnquiryDate = currentDate,
                    EnquiryOpen = "open"
                });
            }
        }
    }
}