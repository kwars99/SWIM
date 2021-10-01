using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWIM.Models;
using SWIM.Views;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        
        private List<Bill> data = new List<Bill>();
        private List<Bill> unpaidBills = new List<Bill>();
        private List<FormattedBill> paidBills = new List<FormattedBill>();
        private bool isEnabled;
        private bool isReminderVisible, isLabelVisible;

        public ICommand GoToPayment { get; }
        public ICommand OpenPDFCommand { get; }
        public ICommand RequestExtensionCommand { get; }

        public List<Bill> Data
        {
            get 
            { 
                return data; 
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }

        public List<FormattedBill> PaidBills
        {
            get
            {
                return paidBills;
            }
            set
            {
                if (paidBills != value)
                {
                    paidBills = value;
                    OnPropertyChanged(nameof(PaidBills));
                }
            }
        }

        public List<Bill> UnPaidBills
        {
            get
            {
                
                return unpaidBills;
            }
            set
            {
                if (unpaidBills != value)
                {
                    unpaidBills = value;
                    OnPropertyChanged(nameof(UnPaidBills));
                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }
        
        public bool IsReminderVisible
        {
            get
            {
                return isReminderVisible;
            }
            set
            {
                if (isReminderVisible != value)
                {
                    isReminderVisible = value;
                    OnPropertyChanged(nameof(IsReminderVisible));
                }
            }
        }

        public bool IsLabelVisible
        {
            get
            {
                return isLabelVisible;
            }
            set
            {
                if (isLabelVisible != value)
                {
                    isLabelVisible = value;
                    OnPropertyChanged(nameof(IsLabelVisible));
                }
            }
        }

        public BillViewModel()
        {
            GoToPayment = new Command(OnPayBillClicked);
            OpenPDFCommand = new Command(OnOpenClicked);
            RequestExtensionCommand = new Command(OnRequestExtensionClicked);

            data = App.Database.GetBillAsync();

            //For testing the payment function
            //adds in an unpaid bill
            data[data.Count - 1].PaidStatus = "unpaid";
            App.Database.UpdateBillAsync(data[data.Count - 1]);

            unpaidBills = data.Where(x => x.PaidStatus == "unpaid").ToList();

            if (unpaidBills.Count == 0)
            {
                IsLabelVisible = true;
                IsReminderVisible = false;
                IsEnabled = false;
            }
            else
            {
                IsReminderVisible = true;
                IsLabelVisible = false;
                IsEnabled = true;
            }

            data.Reverse();
            FormatPaidBills();
            
        }
            
        private async void OnOpenClicked()
        {
            var route = $"{nameof(PdfPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private List<FormattedBill> FormatPaidBills()
        {
            List<Bill> paid = data.Where(x => x.PaidStatus == "paid").ToList();
            for (int i = 0; i < paid.Count; i++)
            {
                string period = paid[i].PeriodStart.ToString("MMM \"'\"yy") + "-" + 
                    paid[i].PeriodEnd.ToString("MMM \"'\"yy");
                double amount = paid[i].Amount;

                FormattedBill paidbill = new FormattedBill(period, amount);
                paidBills.Add(paidbill);
            }

            return paidBills;
        }

        private async void OnPayBillClicked()
        {
            var route = $"{nameof(PaymentPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void OnRequestExtensionClicked()
        {
            var route = $"{nameof(PaymentExtensionPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
