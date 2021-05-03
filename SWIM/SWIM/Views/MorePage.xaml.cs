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
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        async void OnLogoutButtonClicked (object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}