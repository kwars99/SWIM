using SWIM.Models;
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
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        async void OnLogoutButtonClicked (object sender, EventArgs e)
        {
            SecureStorage.Remove(Constants.UserKey);
            SecureStorage.Remove(Constants.PwdKey);

            App.IsUserLoggedIn = false;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        async void OnNotImplementedClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Out of scope", "Feature not implemented.", "Back");
        }

        async void OnFAQOrAboutClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Out of scope", "Feature not implemented. Company information would go here.", "Back");
        }
    }
}