using SWIM.Models;
using SWIM.Services;
using SWIM.ViewModels;
using SWIM.Views;
using Syncfusion.SfChart.XForms;
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
    public partial class UpdateDetails : ContentPage
    {
        public UpdateDetails()
        {
            InitializeComponent();
        }

        User user;
        void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = e.CurrentSelection[0] as User;
            addressEntry.Text = user.Address;
            emailEntry.Text = user.Email;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            if(user != null)
            {
                user.Address = addressEntry.Text;
                user.Email = emailEntry.Text;
                App.Database.GetUserDetailsAsync(user);
                Collection.ItemsSource = App.Database.GetUserDetailsAsync(user);
            }
        }
    }
}