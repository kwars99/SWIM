using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWIM.Models;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    class DashBoardViewModel : INotifyPropertyChanged
    {
        private List<Bill> billData = new List<Bill>();
        private List<Usage> usageData = new List<Usage>();
        private List<FormattedUsage> totalUsages = new List<FormattedUsage>();

        public List<Bill> BillData
        {
            get
            {
                return billData;

            }

            set
            {
                if (billData != value)
                {
                    billData = value;
                    OnPropertyChanged(nameof(BillData));
                }
            }

        }

        public List<Usage> UsagaData
        {
            get
            {
                return usageData;

            }

            set
            {
                if (usageData != value)
                {
                    usageData = value;
                    OnPropertyChanged(nameof(UsagaData));
                }
            }

        }

        public List<FormattedUsage> TotalUsages
        {
            get
            {
                return totalUsages;

            }

            set
            {
                if (totalUsages != value)
                {
                    totalUsages = value;
                    OnPropertyChanged(nameof(TotalUsages));
                }
            }

        }

        public DashBoardViewModel()
        {
            usageData = App.Database.GetUsageAsync();
            usageData.Reverse();
            CalculateTotalUsages();
        }

        private List<FormattedUsage> CalculateTotalUsages()
        {
            usageData = billData.Where(x => x.PaidStatus = "unpaid");
            string period = usageData[2].ReadingDate.ToString("MMM \"'\"yy") + "-" +
                                usageData[0].ReadingDate.ToString("MMM \"'\"yy");
            double usageAmount = usageData[0].Amount + usageData[1].Amount + usageData[2].Amount;

            string usageID1 = usageData[0].UsageID.ToString();
            string usageID2 = usageData[1].UsageID.ToString();
            string usageID3 = usageData[2].UsageID.ToString();

            string IDs = String.Format("{0},{1},{2}", usageID1, usageID2, usageID3);

            double costAmount = billData[0].Amount;

            FormattedUsage formatted = new FormattedUsage(period, usageAmount, costAmount);

            totalUsages.Add(formatted);

            return totalUsages;
        }


        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

