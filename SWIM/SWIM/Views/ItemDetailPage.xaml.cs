using SWIM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SWIM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}