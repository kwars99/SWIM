using SWIM.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SWIM.Droid.AlertViewAndroid))]
namespace SWIM.Droid
{
    public class AlertViewAndroid : IAlertView
    {
        public void Show(string message)
        {
            Application.Current.MainPage.DisplayAlert("", message, "Ok");
        }
    }
}