using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class MorePageViewModel
    {
        public ICommand ViewTransactionHistoryCommand { get; }
        public ICommand ViewBillingPreferencesCommand { get; }

        public MorePageViewModel()
        {
            ViewTransactionHistoryCommand = new Command(OnTransactionHistoryClicked);
            ViewBillingPreferencesCommand = new Command(OnBillingPreferencesClicked);
        }

        private async void OnBillingPreferencesClicked(object obj)
        {
            var route = $"{nameof(BillingPreferencesPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void OnTransactionHistoryClicked(object obj)
        {
            var route = $"{nameof(HistoryPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
