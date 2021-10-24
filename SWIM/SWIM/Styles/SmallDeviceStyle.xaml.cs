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
    public partial class SmallDeviceStyle : ResourceDictionary
    {
        public static SmallDeviceStyle SharedInstance { get; } = new SmallDeviceStyle();
        public SmallDeviceStyle()
        {
            InitializeComponent();
        }
    }
}