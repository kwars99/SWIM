using System;
using System.Collections.Generic;
using SWIM.Models;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SWIM.Views;

namespace SWIM.ViewModels
{
    public class PaymentExtensionViewModel : BaseViewModel
    {
        private List<Bill> billData = new List<Bill>();
        private List<Bill> unpaidBills = new List<Bill>();
        private DateTime minimumDate, maximumDate, selectedDate, dueDate;

        public ICommand PaymentExtensionCommand { get; }

        public double BillAmount
        {
            get
            {
                return unpaidBills[0].Amount;
            }
        }

        public DateTime DueDate
        {
            get
            {
                dueDate = unpaidBills[0].DueDate;
                return dueDate;
            }
        }

        public DateTime MinimumDate
        {
            get
            {
                return minimumDate;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        
        public DateTime MaximumDate
        {
            get
            {
                return maximumDate;
            }
            set
            {
                if (maximumDate != value)
                {
                    maximumDate = value;
                    OnPropertyChanged(nameof(MaximumDate));
                }
            }
        }

        public PaymentExtensionViewModel()
        {
            PaymentExtensionCommand = new Command(OnPaymentExtensionClicked);

            billData = App.Database.GetBillAsync();
            unpaidBills = billData.Where(x => x.PaidStatus == "unpaid").ToList();
            maximumDate = unpaidBills[0].DueDate.AddDays(31);
            minimumDate = unpaidBills[0].DueDate.AddDays(-14);
        }

        private async void OnPaymentExtensionClicked(object obj)
        {
            unpaidBills[0].DueDate = SelectedDate;
            await App.Database.UpdateBillAsync(unpaidBills[0]);

            var route = $"///{nameof(BillsPage)}";
            await Shell.Current.GoToAsync(route);
            //update bill duie date to selected date
            //display pop up
            //go to bills page
        }
    }
}
