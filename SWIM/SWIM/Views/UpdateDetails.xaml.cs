using SWIM.Models;
using SWIM.Services;
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
    public partial class UpdateDetails : ContentPage
    {
        public UpdateDetails()
        {
            InitializeComponent();
        }


        void UpdateBtn(object sender, EventArgs e)
        {
            //App.Database.UpdateUserAsync(user);
            
        }
    }
}