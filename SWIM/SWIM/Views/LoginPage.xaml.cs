using SWIM.Models;
using SWIM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        
        protected override async void OnAppearing()
        {
            if (App.IsUserLoggedIn)
            {
                await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
            }
        }

        async void OnNotImplementedClicked (object sender, EventArgs e)
        {
            await DisplayAlert("Out of scope", "Feature not implemented due to not having access to server", "Back");
        }      
    }
}