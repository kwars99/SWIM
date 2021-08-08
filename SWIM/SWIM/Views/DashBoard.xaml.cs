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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BillsPage());
        }


        //protected override async void onappearing()
        //{
        //    //base.onappearing();

        //    // retrieve all the notes from the database, and set them as the
        //    // data source for the collectionview.
        //    collectionview.itemssource = await app.database.getusersasync();
        //}

    }
}