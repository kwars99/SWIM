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
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OutagePage());
        }
    }
}