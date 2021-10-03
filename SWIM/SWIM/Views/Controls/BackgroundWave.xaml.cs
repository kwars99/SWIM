using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackgroundWave : Grid
    {
        public BackgroundWave()
        {
            InitializeComponent();
        }
    }
}