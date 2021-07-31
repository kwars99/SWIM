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
    public partial class UsagePage : ContentPage
    {
        public UsagePage()
        {
            InitializeComponent();
            
            (BindingContext as UsageViewModel).ChartEntries = App.Database.GetUsageAsync().Take(3).ToList();
            (BindingContext as UsageViewModel).Data = App.Database.GetUsageAsync();
        }

        void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
        }
    }
}