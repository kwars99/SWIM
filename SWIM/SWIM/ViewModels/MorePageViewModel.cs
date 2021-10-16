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
        public ICommand ViewMyAccountCommand { get; }

        public MorePageViewModel()
        {
            ViewTransactionHistoryCommand = new Command(OnTransactionHistoryClicked);
            ViewMyAccountCommand = new Command(OnMyAccountClicked);
        }

        private async void OnMyAccountClicked(object obj)
        {
            var route = $"{nameof(MyAccountPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void OnTransactionHistoryClicked(object obj)
        {
            var route = $"{nameof(HistoryPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
