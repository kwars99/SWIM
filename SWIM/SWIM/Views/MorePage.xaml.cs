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

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(UpdateDetails)}");
        }
    }
}