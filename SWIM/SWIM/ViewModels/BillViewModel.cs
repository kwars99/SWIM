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

        public ICommand OpenPDFCommand { get; }

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
                if (paidBills != null)
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
                List<Bill> unpaidBills = data.Where(x => x.PaidStatus == "unpaid").ToList();
                return unpaidBills;
            }
            set
            {
                if (unpaidBills != null)
                {
                    unpaidBills = value;
                    OnPropertyChanged(nameof(UnPaidBills));
                }
            }
        }

        public BillViewModel()
        {
            data = App.Database.GetBillAsync();
            data.Reverse();
            FormatPaidBills();
            OpenPDFCommand = new Command(OnOpenClicked);
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
