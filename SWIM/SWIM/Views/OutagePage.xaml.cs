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
    public partial class OutagePage : ContentPage
    {
        public OutagePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(description.Text) && !string.IsNullOrWhiteSpace(location.Text))
            {
                DateTime currentDate = DateTime.Now;
                await App.Database.InsertFaultAsync(new Models.Fault() { 
                    DateSubmitted = currentDate, 
                    Desciption = description.Text, 
                    EstimatedFixDate = currentDate.AddDays(7), 
                    Location = location.Text });
            }
        }
    }
}