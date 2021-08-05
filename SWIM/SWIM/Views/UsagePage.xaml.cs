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

            BindingContext = new UsageViewModel();
        }

        void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            
            if (button.Content.ToString() == "Cost")
            {
                chartSeries.YBindingPath = "Cost";
                yAxis.LabelStyle.LabelFormat = "$###";
                chartSeries.Animate();
            }
            else
            {
                chartSeries.YBindingPath = "TotalUsage";
                yAxis.LabelStyle.LabelFormat = "## kL";
                chartSeries.Animate();
            }
        }
    }
}