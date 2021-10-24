using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralDeviceStyle : ResourceDictionary
    {
        public static GeneralDeviceStyle SharedInstance { get; } = new GeneralDeviceStyle();
        public GeneralDeviceStyle()
        {
            InitializeComponent();
        }
    }
}