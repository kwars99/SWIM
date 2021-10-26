using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.PdfViewer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsPage : ContentPage
    {
        public BillsPage()
        {
            InitializeComponent();
        }

        async void OnNotImplementedClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Out of scope", "Feature not implemented.", "Back");
        }
        
    }
}