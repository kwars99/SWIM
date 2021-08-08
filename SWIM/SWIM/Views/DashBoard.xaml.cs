using SWIM.Models;
using SWIM.ViewModels;
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
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();

            BindingContext = new DashBoardViewModel();
        }

        
        //protected override async void OnAppearing()
        //{
            //base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            //collectionView.ItemsSource = await App.Database.GetUsersAsync();
        //}
        
    }
}