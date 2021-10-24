using SWIM.Models;
using SWIM.ViewModels;
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
    public partial class EditDetailsPage : ContentPage
    {
        public EditDetailsPage()
        {
            InitializeComponent();
            BindingContext = new EditDetailsViewModel();
        }
    }
}
